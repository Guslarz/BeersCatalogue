using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.BLC
{
    public class DbParams : IDbParams
    {
        public string Name { get; }

        public string Path { get; }

        public DbParams(string dbName, string dbPath)
        {
            Name = dbName;
            Path = dbPath;
        }
    }
}
