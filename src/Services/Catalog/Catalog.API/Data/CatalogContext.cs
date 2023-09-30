using Catalog.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DbSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DbSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DbSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
