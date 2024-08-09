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
                MenuDisplay.HandleUserChoice(choice, operations, ref exit);
            }
        }
    }
}
