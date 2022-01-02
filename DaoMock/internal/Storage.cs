using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System.Collections.Generic;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Storage
    {
        public Storage()
        {
            Breweries = new Dictionary<int, Brewery>()
            {
                { 0, new Brewery(0, "Brewery1", "State1") },
                { 1, new Brewery(1, "Brewery2", "State1") },
                { 2, new Brewery(2, "Brewery3", "State2") },
            };

            Beers = new Dictionary<int, Beer>()
            {
                { 0, new Beer(0, "Beer1", Breweries[0], 30, 0.04, BeerStyle.Lager) },
                { 1, new Beer(1, "Beer2", Breweries[2], 90, 0.08, BeerStyle.Ipa) },
                { 2, new Beer(2, "Beer3", Breweries[2], 50, 0.09, BeerStyle.Stout) },
            };
        }

        public IDictionary<int, Beer> Beers { get; }
        public IDictionary<int, Brewery> Breweries { get; }
    }
}
