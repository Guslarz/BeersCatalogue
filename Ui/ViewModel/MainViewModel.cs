using Kaczmarek.BeersCatalogue.BLC;
using System.Windows.Input;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class MainViewModel : ViewModel
    {
        public BeersViewModel Beers { get; }
        public BreweriesViewModel Breweries { get; }

        public MainViewModel() : base()
        {
            // get rid of "object reference not set to an instance of an object" error
            if (Blc.Instance != null)
            {
                Beers = new BeersViewModel();
                Breweries = new BreweriesViewModel();
            }
        }
    }
}
