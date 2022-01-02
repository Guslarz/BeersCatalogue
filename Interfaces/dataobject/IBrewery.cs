namespace Kaczmarek.BeersCatalogue.Interfaces
{
    public interface IBrewery : IDataObject
    {
        string Name { get; set; }
        string State { get; set; }
    }
}
