using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class BreweryViewModel : ValidatableViewModel, IBrewery
    {
        private int? _id;
        private string _name;
        private string _city;

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

        [Required]
        [MinLength(3)]
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyProperyChanged();
            }
        }

        public IBrewery Model { get; }

        public BreweryViewModel(IBrewery model) : base()
        {
            _id = model.Id;
            _name = model.Name;
            _city = model.City;
            Model = model;
        }

        public BreweryViewModel(BreweryViewModel viewModel) : this(viewModel.Model)
        {
        }

        public void Save()
        {
            Model.Id = Id;
            Model.Name = Name;
            Model.City = City;
            Blc.Instance.Breweries.Save(Model);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IBrewery))
            {
                return false;
            }
            return Id == (obj as IBrewery).Id;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            return hashCode.ToHashCode();
        }
    }
}
