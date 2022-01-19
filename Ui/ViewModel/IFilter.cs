namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public interface IFilter<T>
    {
        bool Test(T item);
        void Reset();
    }
}
