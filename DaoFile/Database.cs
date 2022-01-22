﻿using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    public class Database : IDatabase
    {
        private Storage _storage;
        public Database(IDbParams dbParams)
        {
            _storage = new Storage();
            Beers = new Dao<Beer, IBeer>(_storage, storage => storage.Beers);
            Breweries = new Dao<Brewery, IBrewery>(_storage, storage => storage.Breweries);
        }

        public IDao<IBeer> Beers { get; }

        public IDao<IBrewery> Breweries { get; }

        public void Dispose()
        {
        }
    }
}
