using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BeerViewModel : ViewModel
    {
        private readonly IBeer _model;

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
        public string Brewery
        {
            get => _model.Brewery?.Name;
            set
            {
                NotifyProperyChanged();
            }
        }
        public int Ibu
        {
            get => _model.Ibu;
            set
            {
                _model.Ibu = value;
                NotifyProperyChanged();
            }
        }
        public double Abv
        {
            get => _model.Abv;
            set
            {
                _model.Abv = value;
                NotifyProperyChanged();
            }
        }
        public BeerStyle Style
        {
            get => _model.Style;
            set
            {
                _model.Style = value;
                NotifyProperyChanged();
            }
        }

        public BeerViewModel(IBeer model) : base()
        {
            _model = model;
        }
    }
}
