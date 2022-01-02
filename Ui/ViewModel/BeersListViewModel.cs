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

        public void AddNewBeer()
        {
            var model = Blc.Instance.Beers.Create();
            model.Name = "New Beer";
            Add(new BeerViewModel(model));
        }

        private static IEnumerable<BeerViewModel> loadBeers()
        {
            return Blc.Instance.Beers.GetAll()
                .Select(beer => new BeerViewModel(beer));
        }
    }
}
