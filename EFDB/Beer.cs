using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;

namespace EFDB
{
    internal class Beer : IBeer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IBrewery Brewery { get; set; }
        public int Ibu { get; set; }
        public double Abv { get; set; }
        public BeerStyle Style { get; set; }
    }
}
