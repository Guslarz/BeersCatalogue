using Kaczmarek.BeersCatalogue.Interfaces;
using System;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweryFilterViewModel : ViewModel, IFilter<IBrewery>
    {
        private string _name;
        private string _city;
        
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyProperyChanged();
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyProperyChanged();
            }
        }

        public BreweryFilterViewModel()
        {
            Reset();
        }

        public bool Test(IBrewery item)
        {
            return
                (Name != null ? item.Name.ToLower().Contains(Name.ToLower()) : true) &&
                (City != null ? item.City.ToLower().Contains(City.ToLower()) : true);
        }

        public void Reset()
        {
            _name = null;
            _city = null;
        }
    }
}
