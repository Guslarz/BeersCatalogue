namespace Kaczmarek.BeersCatalogue.DaoSql
{
    internal interface IStoredModel<T>
    {
        void Assign(T other);
    }
}
