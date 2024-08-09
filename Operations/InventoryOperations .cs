using Inventory_Management_System.Interfaces;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Operations
{

    public class InventoryOperations
    {
        private readonly Iinventory _inventory;

        public InventoryOperations(Iinventory inventory)
        {
            _inventory = inventory;
        }

        public void AddProduct()
        {
            try
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Product name cannot be empty.");
                    return;
                }

                decimal price = ReadDecimal("Enter product price: ");
                if (price < 0)
                {
                    Console.WriteLine("Price must be a positive number.");
                    return;
                }

                int quantity = ReadInt("Enter product quantity: ");
                if (quantity < 0)
                {
                    Console.WriteLine("Quantity must be a positive number.");
                    return;
                }

                IProduct product = new Product(name, price, quantity);
                _inventory.AddProduct(product);
                Console.WriteLine("Product added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewAllProducts()
        {
            try
            {
                var products = _inventory.GetAllProducts();
                if (!products.Any())
                {
                    Console.WriteLine("No products in the inventory.");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private decimal ReadDecimal(string Decimal)
        {
            Console.Write(Decimal);
            if (decimal.TryParse(Console.ReadLine(), out decimal result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Invalid input. Please enter a valid decimal number.         ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                return ReadDecimal(Decimal);
            }
        }

        private int ReadInt(string Int)
        {
            Console.Write(Int);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Invalid input. Please enter a valid integer.                ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                return ReadInt(Int);
            }
        }
    }
}

