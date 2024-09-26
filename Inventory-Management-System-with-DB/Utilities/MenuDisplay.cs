namespace Inventory_Management_System.Utilities
{
    public class MenuDisplay
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         INVENTORY MANAGEMENT           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\nWelcome to the Inventory Management System.");
            Console.WriteLine("Please select an option from the menu below:\n");

            Console.WriteLine("  [1] Add Product");
            Console.WriteLine("  [2] View All Products");
            Console.WriteLine("  [3] Edit Product");
            Console.WriteLine("  [4] Delete Product");
            Console.WriteLine("  [5] Search Product");
            Console.WriteLine("  [6] Exit");
            Console.WriteLine("\n--------------------------------------------");
            Console.Write("Your choice (1-6): ");
        }

        public static void ShowInvalidInputMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      Invalid input. Please enter a number between 1 and 6.             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void ShowExitMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║      Thank you for using the system!   ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void ShowReturnToMenuMessage()
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
