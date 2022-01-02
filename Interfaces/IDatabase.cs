using System;

namespace Kaczmarek.BeersCatalogue.Interfaces
{
    public interface IDatabase : IDisposable
    {
        IDao<IBeer> Beers { get; }
        IDao<IBrewery> Breweries { get; }
    }
}
