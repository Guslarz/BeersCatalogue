using Kaczmarek.BeersCatalogue.Core;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class StoredBeer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreweryId { get; set; }
        public int Ibu { get; set; }
        public double Abv { get; set; }
        public BeerStyle Style { get; set; }

        public StoredBeer()
        {
        }

        public StoredBeer(int id, string name, int breweryId, int ibu, double abv, BeerStyle style)
        {
            Id = id;
            Name = name;
            BreweryId = breweryId;
            Ibu = ibu;
            Abv = abv;
            Style = style;
        }
    }
}
