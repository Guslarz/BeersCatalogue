using Kaczmarek.BeersCatalogue.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Kaczmarek.BeersCatalogue.BLC
{
    public class Blc : IDatabase
    {
        private static readonly string _dllPathFormat = @"{0}.dll";

        public static Blc Instance { get; private set; }

        private IDatabase _database;

        public IDao<IBeer> Beers => _database.Beers;

        public IDao<IBrewery> Breweries => _database.Breweries;

        public static void Initialize(IDbParams dbParams)
        {
            Instance = new Blc(dbParams);
        }

        public static void Close()
        {
            Instance.Dispose();
        }

        private Blc(IDbParams dbParams)
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
