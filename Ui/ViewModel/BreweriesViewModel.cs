using Kaczmarek.BeersCatalogue.BLC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweriesViewModel : CollectionViewModel<BreweryViewModel>
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
        }

        protected override void Select(object obj)
        {
            Selected = obj != null ? new BreweryViewModel((BreweryViewModel)obj) : null;
        }
    }
}
