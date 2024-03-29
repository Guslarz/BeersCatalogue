﻿using Kaczmarek.BeersCatalogue.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Dao<T, I> : IDao<I>
        where T : I, IStoredModel<I>, new()
        where I : IDataObject
    {
        private readonly IDictionary<int, T> _store;
        private int _nextId;

        public Dao(IDictionary<int, T> store)
        {
            _store = store;
            _nextId = _store.Count;
        }

        public I Create()
        {
            return new T();
        }

        public void Delete(I item)
        {
            _store.Remove(item.Id.Value);
        }

        public IEnumerable<I> GetAll()
        {
            return _store.Values
                .Select(item => item.Clone());
        }

        public I GetById(int id)
        {
            return _store[id].Clone();
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
        }

        private void Update(I item)
        {
            _store[item.Id.Value].Assign(item);
        }

        private void Insert(I item)
        {
            T stored = new T();
            stored.Id = _nextId;
            stored.Assign(item);
            _store[_nextId] = stored;
            ++_nextId;
        }
    }
}
