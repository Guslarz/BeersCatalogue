using Kaczmarek.BeersCatalogue.BLC;
using System.Windows.Input;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class MainViewModel : ViewModel
    {
        private BeerViewModel _newBeer;
        public BeersListViewModel Beers { get; }
        public BreweriesListViewModel Breweries { get; }
        public ICommand CreateNewBeerCommand { get; }
        public ICommand SaveNewBeerCommand { get; }
        public BeerViewModel NewBeer
        {
            get => _newBeer;
            set
            {
                _newBeer = value;
                NotifyProperyChanged();
            }
        }
        
        public MainViewModel() : base()
        {
            Beers = new BeersListViewModel();
            Breweries = new BreweriesListViewModel();
            CreateNewBeerCommand = new RelayCommand(param => CreateNewBeer());
            SaveNewBeerCommand = new RelayCommand(param => SaveNewBeer());
            NewBeer = null;
        }

        public void CreateNewBeer()
        {
            var model = Blc.Instance.Beers.Create();
            model.Name = "New Beer";
            NewBeer = new BeerViewModel(model);
        }

        public void SaveNewBeer()
        {
            if (!NewBeer.HasErrors)
            {
                Blc.Instance.Beers.Save(NewBeer);
                NewBeer = null;
            }
        }
    }
}
