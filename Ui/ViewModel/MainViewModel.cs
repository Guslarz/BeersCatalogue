using System.Windows.Input;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class MainViewModel : ViewModel
    {
        public BeersListViewModel Beers { get; }
        public ICommand AddNewBeerCommand { get; }
        
        public MainViewModel() : base()
        {
            Beers = new BeersListViewModel();
            AddNewBeerCommand = new RelayCommand(param => Beers.AddNewBeer());
        }
    }
}
