using Kaczmarek.BeersCatalogue.BLC;
using System.Collections.Generic;
using System.Linq;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BeersViewModel : CollectionViewModel<BeerViewModel>
    {
        protected override void Create()
        {
            var model = Blc.Instance.Beers.Create();
            model.Name = "New Beer";
            _draft = new BeerViewModel(model);
            Selected = _draft;
        }

        protected override IEnumerable<BeerViewModel> Load()
        {
            return Blc.Instance.Beers.GetAll()
                .Select(beer => new BeerViewModel(beer));
        }

        protected override void Save()
        {
            Blc.Instance.Beers.Save(Selected);
            Selected = null;
            LoadList();
        }

        protected override void Select(object beer)
        {
            Selected = (BeerViewModel)beer;
        }
    }
}
