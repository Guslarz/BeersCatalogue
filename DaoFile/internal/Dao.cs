using Kaczmarek.BeersCatalogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class Dao<T, I> : IDao<I>
        where T : I, IModel<I>, new()
        where I : IDataObject
    {
        private readonly Storage _storage;
        private readonly Func<Storage, IDictionary<int, T>> _storeGetter;
        private int _nextId;

        private IDictionary<int, T> _store { get => _storeGetter(_storage); }

        public Dao(Storage storage, Func<Storage, IDictionary<int, T>> storeGetter)
        {
            _storage = storage;
            _storeGetter = storeGetter;
            _nextId = _store.Keys.Count > 0 ? _store.Keys.Max() + 1 : 1;
        }

        public I Create()
        {
            return new T();
        }

        public void Delete(I item)
        {
            _store.Remove(item.Id.Value);
            _storage.Persist();
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
            _storage.Persist();
        }

        private void Update(I item)
        {
            _store[item.Id.Value].Assign(item);
        }

        private void Insert(I item)
        {
            item.Id = _nextId;
            T stored = new T();
            stored.Assign(item);
            _store[_nextId] = stored;
            ++_nextId;
        }
    }
}
