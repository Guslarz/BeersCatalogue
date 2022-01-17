using Kaczmarek.BeersCatalogue.BLC;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BeersListViewModel : ObservableCollection<BeerViewModel>
    {
        public BeersListViewModel() : base(loadBeers())
        {
        }

        private static IEnumerable<BeerViewModel> loadBeers()
        {
            return Blc.Instance.Beers.GetAll()
                .Select(beer => new BeerViewModel(beer));
        }
    }
}
