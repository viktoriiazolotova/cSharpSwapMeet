using System;

namespace cSharpSwapMeet
{
    public class MenuManager
    {

        private bool displayMenu = true;
        private ServiceManager newInstanceServiceManager = new ServiceManager();
        public void RunMenu()
        {
            do
            {
                DisplayMenu();

                string? choice = GetUserInput();

                switch (choice)
                {
                    case "1":
                        newInstanceServiceManager.DisplayAllVendorsAndInventory();
                        break;
                    case "2":
                        newInstanceServiceManager.AddVendorAndInventory();
                        break;
                    case "3":
                        newInstanceServiceManager.ChangeVendorNameAndSaveToFile();
                        break;
                    case "4":
                        newInstanceServiceManager.GetInventoryListingForVendor();
                        break;
                    case "5":
                        newInstanceServiceManager.AddItemToInventoryForVendorAndSaveToFile();
                        break;
                    case "6":
                        newInstanceServiceManager.RemoveItemFromVendorAndSaveToFile();
                        break;
                    case "7":
                        newInstanceServiceManager.DisplayItemsByCategoryForVendor();
                        break;
                    case "8":
                        Console.WriteLine("This feature is in progress...");
                        break;
                    case "9":
                        Console.WriteLine("This feature is in progress...");
                        break;
                    case "10":
                        Console.WriteLine("This feature is in progress...");
                        break;
                    case "11":
                        Console.WriteLine("This feature is in progress...");
                        break;
                    case "12":
                        Console.WriteLine("Exiting the program. Bye!");
                        displayMenu = false;
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 13.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            } while (displayMenu);
        }

        private void DisplayMenu()
        {
            Console.Clear();


            Console.WriteLine("Welcome to The Swap Meet application");
            Console.WriteLine("\nMenu:\n");
            Console.WriteLine("1. List all vendors and their inventory");
            Console.WriteLine("2. Add a new vendor and their inventory");
            Console.WriteLine("3. Edit a vendor name");
            Console.WriteLine("4. Get inventory listing for the specific vendor");
            Console.WriteLine("5. Add an item to the vendor's inventory");
            Console.WriteLine("6. Remove an item from the vendor's inventory");
            Console.WriteLine("7. Get all items by category for the specific vendor");
            Console.WriteLine("8. Check item availability in vendor inventory");
            Console.WriteLine("9. Get best item by category for a vendor");
            Console.WriteLine("10. Swap specific items between vendors");
            Console.WriteLine("11. Swap best items between vendors");
            Console.WriteLine("12. Exit");

        }

        private string? GetUserInput()
        {
            Console.Write("\nEnter your choice (1-12): ");
            return Console.ReadLine();
        }

    }
}