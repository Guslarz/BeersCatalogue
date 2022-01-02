using Kaczmarek.BeersCatalogue.Interfaces;

namespace Kaczmarek.BeersCatalogue.DaoMock
{
    internal class Brewery : IBrewery, IStoredModel<IBrewery>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public Brewery()
        {
        }

        public Brewery(int? id, string name, string state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public Brewery(IBrewery other) : this(other.Id, other.Name, other.State)
        {
        }

        public IBrewery Clone()
        {
            return new Brewery(this);
        }

        public void Assign(IBrewery other)
        {
            Name = other.Name;
            State = other.State;
        }
    }
}
