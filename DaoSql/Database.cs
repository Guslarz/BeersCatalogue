using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    public class Database : IDatabase
    {
        private readonly BeersCatalogueContext _context;

        public IDao<IBeer> Beers { get; }

        public IDao<IBrewery> Breweries { get; }

        public Database(IDbParams dbParams)
        {
            SQLitePCL.Batteries.Init();
            _context = new BeersCatalogueContext(dbParams.Path);
            Beers = new Dao<Beer, IBeer>(_context, () => _context.Beers);
            Breweries = new Dao<Brewery, IBrewery>(_context, () => _context.Breweries);

            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
