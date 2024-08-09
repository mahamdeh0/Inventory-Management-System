using Inventory_Management_System.Utilities;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            MenuDisplay.ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
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
                    Console.ReadKey(); 
                    break;
            }
        }
    }
}
