using Kaczmarek.BeersCatalogue.Core;

namespace Kaczmarek.BeersCatalogue.Interfaces
{
    public interface IBeer : IDataObject
    {
        string Name { get; set; }
        IBrewery Brewery { get; set; }
        int Ibu { get; set; }
        double Abv { get; set; }
        BeerStyle Style { get; set; }
    }
}
