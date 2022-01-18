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
            throw new NotImplementedException();
        }

        protected override IEnumerable<BreweryViewModel> Load()
        {
            return Blc.Instance.Breweries.GetAll()
                .Select(brewery => new BreweryViewModel(brewery));
        }

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Select(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
