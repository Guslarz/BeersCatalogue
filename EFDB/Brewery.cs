using Kaczmarek.BeersCatalogue.Interfaces;

namespace EFDB
{
    internal class Brewery : IBrewery
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
