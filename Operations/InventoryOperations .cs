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

        public void EditProduct()
        {
            try
            {
                Console.Write("Enter the name of the product to edit: ");
                string name = Console.ReadLine();
                var product = _inventory.GetProductByName(name);

                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                bool continueEditing = true;
                while (continueEditing)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Current Product Details: Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                    Console.ResetColor();
                    Console.WriteLine("Which detail would you like to edit?");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Price");
                    Console.WriteLine("3. Quantity");
                    Console.WriteLine("4. Finish editing");
                    Console.Write("Enter the number of the detail to edit (1-4): ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter new name: ");
                            string newName = Console.ReadLine();
                            product.Name = newName;
                            break;

                        case 2:
                            Console.Write("Enter new price: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            if (price < 0)
                            {
                                Console.WriteLine("Price must be a positive number.");
                                continue;
                            }
                            product.Price = price;
                            break;

                        case 3:
                            Console.Write("Enter new quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            if (quantity < 0)
                            {
                                Console.WriteLine("Quantity must be a positive number.");
                                continue;
                            }
                            product.Quantity = quantity;
                            break;

                        case 4:
                            continueEditing = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                            Console.WriteLine("║ Invalid choice. Please select a valid option.         ║");
                            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            break;
                    }
                }

                _inventory.UpdateProduct(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═════════════════════════════════════════════════╗");
                Console.WriteLine("║ Product updated successfully.                   ║");
                Console.WriteLine("╚═════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine($"Updated Product Details: Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void DeleteProduct()
        {
            try
            {
                Console.Write("Enter the name of the product to delete: ");
                string name = Console.ReadLine();

                var product = _inventory.GetProductByName(name);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                _inventory.DeleteProduct(name);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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

