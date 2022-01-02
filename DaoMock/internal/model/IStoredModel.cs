using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal interface IStoredModel<T> : IDataObject
    {
        T Clone();
        void Assign(T other);
    }
}
