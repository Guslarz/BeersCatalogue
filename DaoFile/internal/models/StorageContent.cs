using System.Collections.Generic;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class StorageContent
    {
        public IEnumerable<StoredBeer> Beers { get; set; }
        public IEnumerable<StoredBrewery> Breweries { get; set; }
    }
}
