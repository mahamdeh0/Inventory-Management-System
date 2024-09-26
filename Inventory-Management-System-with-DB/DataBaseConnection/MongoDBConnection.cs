namespace Inventory_Management_System.DatabaseConnection
{
    public class MongoDBConnection
    {
        public static string ConnectionString => "mongodb://localhost:27017"; 
        public static string DatabaseName => "InventoryDB";
    }
}
