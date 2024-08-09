using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Inventory_Management_System.Operations;
using Inventory_Management_System.Utilities;

using System;

namespace InventoryManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Iinventory inventory = new Inventory();
            InventoryOperations operations = new InventoryOperations(inventory);

            bool exit = false;
            while (!exit)
            {
                MenuDisplay.ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        operations.AddProduct();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("╔═════════════════════════════════════════════════╗");
                    Console.WriteLine("║ Press any key to return to the menu...          ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
