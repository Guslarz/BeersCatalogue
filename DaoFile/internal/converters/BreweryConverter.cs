namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class BreweryConverter : IConverter<Brewery, StoredBrewery>
    {
        public StoredBrewery Convert(Brewery model)
        {
            return new StoredBrewery(
                model.Id.Value,
                model.Name,
                model.City
            );
        }

        public Brewery Convert(StoredBrewery stored)
        {
            return new Brewery(
                stored.Id,
                stored.Name,
                stored.City
            );
        }
    }
}
