using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BeerViewModel : ValidatableViewModel, IBeer
    {
        private int? _id;
        private string _name;
        private IBrewery _brewery;
        private int _ibu;
        private double _abv;
        private BeerStyle _style;

        public int? Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyProperyChanged();
            }
        }

        [Required]
        [MinLength(3)]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyProperyChanged();
            }
        }
        
        public IBrewery Brewery
        {
            get => _brewery;
            set
            {
                _brewery = value;
                NotifyProperyChanged();
            }
        }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ibu {0} must be greater than {1}.")]
        public int Ibu
        {
            get => _ibu;
            set
            {
                _ibu = value;
                NotifyProperyChanged();
            }
        }

        [Required]
        [Range(0, 1, ErrorMessage = "Abv must be in range 0, 1")]
        public double Abv
        {
            get => _abv;
            set
            {
                _abv = value;
                NotifyProperyChanged();
            }
        }

        [Required]
        public BeerStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                NotifyProperyChanged();
            }
        }

        public BeerViewModel(IBeer model) : base()
        {
            Id = model.Id;
            Name = model.Name;
            Brewery = model.Brewery;
            Ibu = model.Ibu;
            Abv = model.Abv;
            Style = model.Style;
        }
    }
}
