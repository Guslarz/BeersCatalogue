using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweryViewModel : ViewModel
    {
        private readonly IBrewery _model;

        public int? Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                NotifyProperyChanged();
            }
        }
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                NotifyProperyChanged();
            }
        }
        public string State
        {
            get => _model.State;
            set
            {
                _model.State = value;
                NotifyProperyChanged();
            }
        }

        public BreweryViewModel(IBrewery model) : base()
        {
            _model = model;
        }
    }
}
