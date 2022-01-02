using Kaczmarek.BeersCatalogue.Blc;
using Kaczmarek.BeersCatalogue.DaoSql;
using Kaczmarek.BeersCatalogue.Interfaces;
using System;

namespace ConsoleUi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Properties.Settings settings = Properties.Settings.Default;
            IDbParams dbParams = new DbParams(settings.DbName, settings.DbPath);
            //Blc blc = new Blc(dbParams);
            var blc = new Database(dbParams);
            var newBeer = blc.Beers.Create();
            newBeer.Name = "ASDF";
            blc.Beers.Save(newBeer);
            foreach (var beer in blc.Beers.GetAll())
            {
                Console.WriteLine(beer.Name);
            }

            blc.Dispose();
            Console.ReadKey();
        }
    }
}
