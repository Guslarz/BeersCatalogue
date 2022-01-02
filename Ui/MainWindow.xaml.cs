using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using Kaczmarek.BeersCatalogue.Ui.Properties;
using Kaczmarek.BeersCatalogue.Ui.ViewModel;
using System.Linq;
using System.Windows;

namespace Kaczmarek.BeersCatalogue.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BeerViewModel Beer { get; set; }
        private BeersListViewModel Beers { get; set; }

        public MainWindow() : base()
        {
            Blc.Initialize(loadParams());

            if (Blc.Instance.Beers.GetAll().Count() == 0)
            {
                var newBrewery = Blc.Instance.Breweries.Create();
                newBrewery.Name = "Some brewery";
                Blc.Instance.Breweries.Save(newBrewery);
                var newBeer = Blc.Instance.Beers.Create();
                newBeer.Name = "ASDF";
                newBeer.Brewery = newBrewery;
                Blc.Instance.Beers.Save(newBeer);
            }

            Beer = new BeerViewModel(Blc.Instance.Beers.GetAll().First());
            Beers = new BeersListViewModel();

            InitializeComponent();
        }

        private IDbParams loadParams()
        {
            var settings = Settings.Default;
            return new DbParams(settings.DbName, settings.DbPath);
        }
    }
}
