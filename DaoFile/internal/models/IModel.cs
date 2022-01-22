using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal interface IModel<T> : IDataObject
    {
        T Clone();
        void Assign(T other);
    }
}
