using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    [Table("Beers")]
    internal class Beer : IBeer, IStoredModel<IBeer>
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IBrewery Brewery { get; set; }
        public int Ibu { get; set; }
        public double Abv { get; set; }
        public BeerStyle Style { get; set; }

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
