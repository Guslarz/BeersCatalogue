using Microsoft.EntityFrameworkCore;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    internal class BeersCatalogueContext : DbContext
    {
        private static readonly string _dbFilename = "beersCatalogue.db";

        private readonly string _dbPath;

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }

        public BeersCatalogueContext(string dbPath)
        {
            _dbPath = $"{dbPath}{System.IO.Path.DirectorySeparatorChar}{_dbFilename}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}");
    }
}
