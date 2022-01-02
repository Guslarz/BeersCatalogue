using Kaczmarek.BeersCatalogue.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    internal class Dao<T, I> : IDao<I>
        where T : class, I, IStoredModel<I>, new()
        where I : IDataObject
    {
        private BeersCatalogueContext _db;
        private Func<DbSet<T>> _dbSetGetter;

        public Dao(BeersCatalogueContext db, Func<DbSet<T>> dbSetGetter)
        {
            _db = db;
            _dbSetGetter = dbSetGetter;
        }

        public I Create()
        {
            return new T();
        }

        public void Delete(I item)
        {
            _db.Remove(InternalGetById(item.Id.Value));
            _db.SaveChanges();
        }

        public IEnumerable<I> GetAll()
        {
            return _dbSetGetter();
        }

        public I GetById(int id)
        {
            return InternalGetById(id);
        }

        public void Save(I item)
        {
            if (item.Id.HasValue)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
            _db.SaveChanges();
        }

        private T InternalGetById(int id)
        {
            return _dbSetGetter()
                .Where(item => item.Id == id)
                .First();
        }

        private void Update(I item)
        {
            InternalGetById(item.Id.Value).Assign(item);
        }

        private void Insert(I item)
        {
            T stored = new T();
            stored.Assign(item);
            _db.Add(stored);
            item.Id = stored.Id;
        }
    }
}
