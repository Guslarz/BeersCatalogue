using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Beer : IBeer, IStoredModel<IBeer>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IBrewery Brewery { get; set; }
        public int Ibu { get; set; }
        public double Abv { get; set; }
        public BeerStyle Style { get; set; }

        public Beer()
        {
        }

        public Beer(int? id, string name, IBrewery brewery, int ibu, double abv, BeerStyle style)
        {
            Id = id;
            Name = name;
            Brewery = brewery;
            Ibu = ibu;
            Abv = abv;
            Style = style;
        }

        public Beer(IBeer other) : this(other.Id, other.Name, other.Brewery, other.Ibu, other.Abv, other.Style)
        {
        }

        public IBeer Clone()
        {
            return new Beer(this);
        }

        public void Assign(IBeer other)
        {
            Name = other.Name;
            Brewery = other.Brewery;
            Ibu = other.Ibu;
            Abv = other.Abv;
            Style = other.Style;
        }
    }
}
