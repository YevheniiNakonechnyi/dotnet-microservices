using System;
using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private const string ConnectionString = "DatabaseSettings:ConnectionString";
        private const string DatabaseName = "DatabaseSettings:DatabaseName";
        private const string CollectionName = "DatabaseSettings:CollectionName";

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>(ConnectionString));
            var database = client.GetDatabase(configuration.GetValue<string>(DatabaseName));

            Products = database.GetCollection<Product>(configuration.GetValue<string>(CollectionName));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}