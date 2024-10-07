using MongoDB.Driver;
using MyApi.Models;

namespace MyApi.Data
{
    public class ItemContext
    {
        public ItemContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MyApiDb");
            Items = database.GetCollection<Item>("Items");
        }

        public IMongoCollection<Item> Items { get; }
    }
}
