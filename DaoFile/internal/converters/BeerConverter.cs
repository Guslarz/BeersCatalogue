using Kaczmarek.BeersCatalogue.Interfaces;
using System;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class BeerConverter : IConverter<Beer, StoredBeer>
    {
        private readonly Func<int, IBrewery> _getBreweryById;

        public BeerConverter(Func<int, IBrewery> getBreweryById)
        {
            _getBreweryById = getBreweryById;
        }

        public StoredBeer Convert(Beer model)
        {
            return new StoredBeer(
                model.Id.Value,
                model.Name,
                model.Brewery.Id.Value,
                model.Ibu,
                model.Abv,
                model.Style
            );
        }

        public Beer Convert(StoredBeer stored)
        {
            return new Beer(
                stored.Id,
                stored.Name,
                _getBreweryById(stored.BreweryId),
                stored.Ibu,
                stored.Abv,
                stored.Style
            );
        }
    }
}
