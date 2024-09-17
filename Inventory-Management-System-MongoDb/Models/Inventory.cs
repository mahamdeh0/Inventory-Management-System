using Inventory_Management_System.DatabaseConnection;
using Inventory_Management_System.Interfaces;
using InventoryManagement.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inventory_Management_System.Models
{
    public class Inventory : Iinventory
    {
        private readonly IMongoCollection<BsonDocument> _productsCollection;

        public Inventory()
        {
            var client = new MongoClient(MongoDBConnection.ConnectionString);
            var database = client.GetDatabase(MongoDBConnection.DatabaseName);
            _productsCollection = database.GetCollection<BsonDocument>("Products");
        }

        public async Task AddProduct(IProduct product)
        {
            var document = new BsonDocument
            {
                { "Name", product.Name },
                { "Price", product.Price },
                { "Quantity", product.Quantity }
            };
            await _productsCollection.InsertOneAsync(document);
        }

        public async Task<List<IProduct>> GetAllProducts()
        {
            var products = new List<IProduct>();
            var documents = await _productsCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in documents)
            {
                products.Add(new Product(
                    doc["Name"].AsString,
                    doc["Price"].AsDecimal,
                    doc["Quantity"].AsInt32
                ));
            }

            return products;
        }

        public async Task<IProduct> GetProductByName(string productName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", productName);
            var document = await _productsCollection.Find(filter).FirstOrDefaultAsync();

            if (document != null)
            {
                return new Product(
                    document["Name"].AsString,
                    document["Price"].AsDecimal,
                    document["Quantity"].AsInt32
                );
            }

            return null;
        }

        public async Task UpdateProduct(IProduct product)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", product.Name);
            var update = Builders<BsonDocument>.Update
                .Set("Price", product.Price)
                .Set("Quantity", product.Quantity);

            await _productsCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProduct(string productName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", productName);
            await _productsCollection.DeleteOneAsync(filter);
        }
    }
}
