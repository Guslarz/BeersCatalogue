using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BeerFilterViewModel : ValidatableViewModel, IFilter<IBeer>
    {
        private string _name;
        private IBrewery _brewery;
        private int? _minIbu;
        private int? _maxIbu;
        private double? _minAbv;
        private double? _maxAbv;
        private BeerStyle? _style;

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

        [Range(0, int.MaxValue, ErrorMessage = "Ibu must be greater than {1}.")]
        public int? MinIbu
        {
            get => _minIbu;
            set
            {
                _minIbu = value;
                NotifyProperyChanged();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Ibu must be greater than {1}.")]
        public int? MaxIbu
        {
            get => _maxIbu;
            set
            {
                _maxIbu = value;
                NotifyProperyChanged();
            }
        }

        [Range(0, 1, ErrorMessage = "Abv must be in range 0, 1")]
        public double? MinAbv
        {
            get => _minAbv;
            set
            {
                _minAbv = value;
                NotifyProperyChanged();
            }
        }

        [Range(0, 1, ErrorMessage = "Abv must be in range 0, 1")]
        public double? MaxAbv
        {
            get => _maxAbv;
            set
            {
                _maxAbv = value;
                NotifyProperyChanged();
            }
        }

        public BeerStyle? Style
        {
            get => _style;
            set
            {
                _style = value;
                NotifyProperyChanged();
            }
        }

        public BeerFilterViewModel()
        {
            Reset();
        }

        public bool Test(IBeer item)
        {
            return
                (Name != null ? item.Name.ToLower().Contains(Name.ToLower()) : true) &&
                (Brewery != null ? item.Brewery.Equals(Brewery) : true) &&
                (MinIbu != null ? item.Ibu >= MinIbu : true) &&
                (MaxIbu != null ? item.Ibu <= MaxIbu : true) &&
                (MinAbv != null ? item.Abv >= MinAbv : true) &&
                (MaxAbv != null ? item.Abv <= MaxAbv : true) &&
                (Style != null ? item.Style == Style : true);
        }

        public void Reset()
        {
            Name = null;
            Brewery = null;
            MinIbu = null;
            MaxIbu = null;
            MinAbv = null;
            MaxAbv = null;
            Style = null;
        }
    }
}
