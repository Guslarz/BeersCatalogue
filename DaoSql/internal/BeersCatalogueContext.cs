using Microsoft.EntityFrameworkCore;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    internal class BeersCatalogueContext : DbContext
    {
        // solution root dir
        private static readonly string _dbPath = @"..\..\..\beersCatalogue.db";

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
