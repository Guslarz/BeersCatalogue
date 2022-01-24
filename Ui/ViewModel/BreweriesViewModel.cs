using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweriesViewModel : CollectionViewModel<BreweryViewModel, BreweryFilterViewModel, IBrewery>
    {
        protected override void Create()
        {
            var model = Blc.Instance.Breweries.Create();
            _draft = new BreweryViewModel(model);
            Selected = _draft;
        }

        protected override IEnumerable<BreweryViewModel> Load()
        {
            return Blc.Instance.Breweries.GetAll()
                .Select(brewery => new BreweryViewModel(brewery));
        }

        protected override void Save()
        {
            Blc.Instance.Breweries.Save(Selected);
            _draft = null;
            NotifyProperyChanged(nameof(IsDraftSelected));
            LoadList();
            Selected.IsDirty = false;
        }

        protected override void Select(object obj)
        {
            Selected = obj != null ? new BreweryViewModel((BreweryViewModel)obj) : null;
        }

        protected override void Delete(BreweryViewModel item)
        {
            Blc.Instance.Breweries.Delete(item);
        }
    }
}
