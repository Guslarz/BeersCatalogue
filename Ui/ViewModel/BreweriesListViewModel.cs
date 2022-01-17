using Kaczmarek.BeersCatalogue.BLC;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweriesListViewModel : ObservableCollection<BreweryViewModel>
    {
        public BreweriesListViewModel() : base(loadBreweries())
        {
        }

        private static IEnumerable<BreweryViewModel> loadBreweries()
        {
            return Blc.Instance.Breweries.GetAll()
                .Select(brewery => new BreweryViewModel(brewery));
        }
    }
}
