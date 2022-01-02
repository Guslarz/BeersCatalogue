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

        public Brewery Brewery { get; set; }

        [NotMapped]
        IBrewery IBeer.Brewery
        {
            get => Brewery;
            set => Brewery = value as Brewery;
        }

        public int Ibu { get; set; }
        public double Abv { get; set; }
        public BeerStyle Style { get; set; }

        public void Assign(IBeer other)
        {
            Name = other.Name;
            Brewery = other.Brewery as Brewery;
            Ibu = other.Ibu;
            Abv = other.Abv;
            Style = other.Style;
        }
    }
}
