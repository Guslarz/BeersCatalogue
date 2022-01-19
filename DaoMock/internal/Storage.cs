using Kaczmarek.BeersCatalogue.Core;
using System.Collections.Generic;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Storage
    {
        public Storage()
        {
            Breweries = new Dictionary<int, Brewery>()
            {
                { 0, new Brewery(0, "Pinta", "Wieprz") },
                { 1, new Brewery(1, "Browar Fortuna", "Miłosław") },
                { 2, new Brewery(2, "Browar Za Miastem", "Rumianek") }
            };

            Beers = new Dictionary<int, Beer>()
            {
                { 0, new Beer(0, "Atak Chmielu", Breweries[0], 58, 0.061, BeerStyle.Ipa ) },
                { 1, new Beer(1,  "Na Wypasie", Breweries[2], 35, 0.045, BeerStyle.Ipa) },
                { 2, new Beer(2, "Dobra Noc", Breweries[2], 30, 0.058, BeerStyle.Stout) },
                { 3, new Beer(3, "Komes Porter Bałtycki", Breweries[1], 35, 0.09, BeerStyle.Porter ) },
                { 4, new Beer(4, "Miłosław Witbier", Breweries[1], 17, 0.048, BeerStyle.Other ) },
                { 5, new Beer(5, "Własne Sprawy", Breweries[2], 45, 0.056, BeerStyle.Apa ) },
            };
        }

        public IDictionary<int, Beer> Beers { get; }
        public IDictionary<int, Brewery> Breweries { get; }
    }
}
