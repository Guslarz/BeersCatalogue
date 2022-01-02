using Kaczmarek.BeersCatalogue.Core;
using Kaczmarek.BeersCatalogue.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Kaczmarek.BeersCatalogue.Blc
{
    public class Blc : IDatabase
    {
        // tmp - add post build event later
        private static readonly string _dllPathFormat = @"{0}.dll";

        private IDatabase _database;

        public IDao<IBeer> Beers => _database.Beers;

        public IDao<IBrewery> Breweries => _database.Breweries;

        public Blc(IDbParams dbParams)
        {
            string dllPath = string.Format(_dllPathFormat, dbParams.Name);
            var assembly = Assembly.UnsafeLoadFrom(dllPath);

            Type idaoType = typeof(IDatabase);
            Type dbType = assembly
                .GetExportedTypes()
                .Where(type => type.GetInterfaces().Contains(idaoType))
                .First();
            _database = (IDatabase)Activator.CreateInstance(dbType, dbParams);
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
