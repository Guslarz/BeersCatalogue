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
            _draft = null;
            NotifyProperyChanged(nameof(IsDraftSelected));
            LoadList();
        }

        protected override void Select(object obj)
        {
            Selected = obj != null ? new BeerViewModel((BeerViewModel)obj) : null;
        }
    }
}
