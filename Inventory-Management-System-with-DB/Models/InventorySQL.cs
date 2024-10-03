using Inventory_Management_System.Interfaces;
using InventoryManagement.Core.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Models
{
    public class InventorySQL : Iinventory
    {
        private readonly string _connectionString;

        public InventorySQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddProduct(IProduct product)
        {
            var query = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<IProduct>> GetAllProducts()
        {
            var query = "SELECT * FROM Products";
            var products = new List<IProduct>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product(
                                reader["Name"].ToString(),
                                (decimal)reader["Price"],
                                (int)reader["Quantity"]
                            ));
                        }
                    }
                }
            }

            return products;
        }

        public async Task UpdateProduct(IProduct product)
        {
            var query = "UPDATE Products SET Price = @Price, Quantity = @Quantity WHERE Name = @Name";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteProduct(string productName)
        {
            var query = "DELETE FROM Products WHERE Name = @Name";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IProduct> GetProductByName(string productName)
        {
            var query = "SELECT * FROM Products WHERE Name = @Name";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Product(
                                reader["Name"].ToString(),
                                (decimal)reader["Price"],
                                (int)reader["Quantity"]
                            );
                        }
                        return null;
                    }
                }
            }
        }

    }
}
