using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.SqlServerDatabaseInitializer
{
    public class SqlServerDatabaseInitializer
    {
        private readonly string _connectionString = DataBaseConnection.DataBaseConnection.SqlServerConnectionString;

        public SqlServerDatabaseInitializer()
        {
            CreateProductsTableAsync().Wait();
        }

        private async Task CreateProductsTableAsync()
        {
            var query = """
            IF object_id('Products') IS NULL
            BEGIN
                CREATE TABLE Products (
                    Name NVARCHAR(100) NOT NULL,
                    Price DECIMAL(18, 2) NOT NULL,
                    Quantity INT NOT NULL
                )
            END
            """;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
