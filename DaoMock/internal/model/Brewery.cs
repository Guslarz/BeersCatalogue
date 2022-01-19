using Kaczmarek.BeersCatalogue.Interfaces;
using System;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Brewery : IBrewery, IStoredModel<IBrewery>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Brewery()
        {
        }

        public Brewery(int? id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public Brewery(IBrewery other) : this(other.Id, other.Name, other.City)
        {
        }

        public IBrewery Clone()
        {
            return new Brewery(this);
        }

        public void Assign(IBrewery other)
        {
            Name = other.Name;
            City = other.City;
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
