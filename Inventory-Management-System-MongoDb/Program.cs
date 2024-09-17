using Inventory_Management_System.DataBaseConnection;
using Inventory_Management_System.Models;
using Inventory_Management_System.Operations;
using Inventory_Management_System.SqlServerDatabaseInitializer;
using Inventory_Management_System.Utilities;

namespace InventoryManagement.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            new SqlServerDatabaseInitializer();

            var inventory = new Inventory(DataBaseConnection.SqlServerConnectionString);
            InventoryOperations operations = new InventoryOperations(inventory);

            bool exit = false;
            while (!exit)
            {
                MenuDisplay.ShowMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await operations.AddProduct();
                        break;
                    case "2":
                        await operations.ViewAllProducts();
                        break;
                    case "3":
                        await operations.EditProduct();
                        break;
                    case "4":
                        await operations.DeleteProduct();
                        break;
                    case "5":
                        await operations.SearchProduct();
                        break;
                    case "6":
                        MenuDisplay.ShowExitMessage();
                        exit = true;
                        break;
                    default:
                        MenuDisplay.ShowInvalidInputMessage();
                        break;
                }

                if (choice != "6")
                {
                    MenuDisplay.ShowReturnToMenuMessage();
                }
            }
        }
    }
}
