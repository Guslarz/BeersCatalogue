using System.Collections.Generic;

namespace Kaczmarek.BeersCatalogue.Interfaces
{
    public interface IDao<T> where T : IDataObject
    {
        T Create();
        void Delete(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Save(T item);
    }
}
