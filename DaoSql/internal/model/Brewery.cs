﻿using Kaczmarek.BeersCatalogue.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaczmarek.BeersCatalogue.DaoSql
{
    [Table("Breweries")]
    internal class Brewery : IBrewery, IStoredModel<IBrewery>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public void Assign(IBrewery other)
        {
            Name = other.Name;
            State = other.State;
        }
    }
}