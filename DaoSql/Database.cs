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
            _context = new BeersCatalogueContext();
            Beers = new Dao<Beer, IBeer>(_context, () => _context.Beers);
            Breweries = new Dao<Brewery, IBrewery>(_context, () => _context.Breweries);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
