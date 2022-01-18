using Kaczmarek.BeersCatalogue.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweryViewModel : ValidatableViewModel, IBrewery
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

        [Required]
        [MinLength(3)]
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                NotifyProperyChanged();
            }
        }

        [Required]
        [MinLength(3)]
        public string City
        {
            get => _model.City;
            set
            {
                _model.City = value;
                NotifyProperyChanged();
            }
        }

        public BreweryViewModel(IBrewery model) : base()
        {
            _model = model;
        }
    }
}
