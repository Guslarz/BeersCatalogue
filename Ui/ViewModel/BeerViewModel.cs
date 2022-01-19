using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System;
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

        public IBeer Model { get; }

        public BeerViewModel(IBeer model) : base()
        {
            Id = model.Id;
            Name = model.Name;
            Brewery = model.Brewery;
            Ibu = model.Ibu;
            Abv = model.Abv;
            Style = model.Style;
            Model = model;
        }

        public BeerViewModel(BeerViewModel viewModel) : this(viewModel.Model)
        {
        }

        public void Save()
        {
            Model.Id = Id;
            Model.Name = Name;
            Model.Brewery = Brewery;
            Model.Ibu = Ibu;
            Model.Abv = Abv;
            Model.Style = Style;
            Blc.Instance.Beers.Save(Model);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IBeer))
            {
                return false;
            }
            return Id == (obj as IBeer).Id;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            return hashCode.ToHashCode();
        }
    }
}
