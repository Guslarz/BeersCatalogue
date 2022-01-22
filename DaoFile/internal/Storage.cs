using Kaczmarek.BeersCatalogue.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal class Storage
    {
        // solution root dir
        private static readonly string _dbPath = @"..\..\..\beersCatalogue.json";
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { WriteIndented = true };

        private BreweryConverter _breweryConverter;
        private BeerConverter _beerConverter;
        
        public IDictionary<int, Beer> Beers { get; private set; }
        public IDictionary<int, Brewery> Breweries { get; private set; }

        public Storage()
        {
            _breweryConverter = new BreweryConverter();
            _beerConverter = new BeerConverter(id => Breweries[id]);
            InitializeStorage();
        }

        public void Persist()
        {
            var content = WriteContent();
            var file = File.Open(_dbPath, FileMode.Truncate);
            JsonSerializer.SerializeAsync(file, content, _serializerOptions).Wait();
            file.Close();
        }

        public void Load()
        {
            var file = File.Open(_dbPath, FileMode.Open);
            var task = JsonSerializer.DeserializeAsync<StorageContent>(file);
            task.AsTask().Wait();
            var content = task.Result;
            file.Close();
            LoadContent(content);
        }

        private void InitializeStorage()
        {
            if (!File.Exists(_dbPath))
            {
                Breweries = new Dictionary<int, Brewery>()
                {
                    { 0, new Brewery(0, "Pinta", "Wieprz") },
                    { 1, new Brewery(1, "Browar Fortuna", "Miłosław") },
                    { 2, new Brewery(2, "Browar Za Miastem", "Rumianek") }
                };

                Beers = new Dictionary<int, Beer>()
                {
                    { 0, new Beer(0, "Atak Chmielu", Breweries[0], 58, 0.061, BeerStyle.Ipa ) },
                    { 1, new Beer(1,  "Na Wypasie", Breweries[2], 35, 0.045, BeerStyle.Ipa) },
                    { 2, new Beer(2, "Dobra Noc", Breweries[2], 30, 0.058, BeerStyle.Stout) },
                    { 3, new Beer(3, "Komes Porter Bałtycki", Breweries[1], 35, 0.09, BeerStyle.Porter ) },
                    { 4, new Beer(4, "Miłosław Witbier", Breweries[1], 17, 0.048, BeerStyle.Other ) },
                    { 5, new Beer(5, "Własne Sprawy", Breweries[2], 45, 0.056, BeerStyle.Apa ) },
                };

                File.Create(_dbPath).Close();
                Persist();
            }
            else
            {
                Load();
            }
        }

        private StorageContent WriteContent()
        {
            var content = new StorageContent();
            content.Breweries = Breweries.Values
                .Select(item => _breweryConverter.Convert(item));
            content.Beers = Beers.Values
                .Select(item => _beerConverter.Convert(item));
            return content;
        }

        private void LoadContent(StorageContent content)
        {
            Breweries = content.Breweries
                    .Select(item => _breweryConverter.Convert(item))
                    .ToDictionary(item => item.Id.Value);
            Beers = content.Beers
                    .Select(item => _beerConverter.Convert(item))
                    .ToDictionary(item => item.Id.Value);
        }
    }
}
