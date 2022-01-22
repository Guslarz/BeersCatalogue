namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class StoredBrewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public StoredBrewery()
        {
        }

        public StoredBrewery(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}
