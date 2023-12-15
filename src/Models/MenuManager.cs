using System;
namespace cSharpSwapMeet
{
    public class MenuManager
    {
        //method to test before having FileManager
        private static List<Vendor> GetSampleVendors()
        {
            // Create and return a list of vendors with items in their inventory

            Vendor vendor1 = new Vendor("Vendor1", new List<Item> { new Decor(), new Clothing() });
            Vendor vendor2 = new Vendor("Vendor2", new List<Item> { new Electronics(), new Clothing(), new Decor() });

            List<Vendor> vendors = new List<Vendor> { vendor1, vendor2 };
            return vendors;

        }
        public static void DisplayMenu()
        {
            //this will read from file
            List<Vendor> vendors = GetSampleVendors();
            //rewrite the loop to having the do-while structure similar to pet app
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Welcome to The Swapp Meet application");
                Console.WriteLine("\nMenu:\n");
                Console.WriteLine("1. List all vendors");
                Console.WriteLine("2. Add a new vendor");
                Console.WriteLine("3. Edit a vendor name");
                Console.WriteLine("4. Get inventory listing for the specific vendor");
                Console.WriteLine("5. Add an item to the vendor's inventory");
                Console.WriteLine("6. Remove an item from the vendor's inventory");
                Console.WriteLine("7. Get all items by category for the specific vendor");
                Console.WriteLine("8. Check item availability");
                Console.WriteLine("9. Get best item by category for a vendor");
                Console.WriteLine("10. Swap specific items between vendors");
                Console.WriteLine("11. Swap best items between vendors");
                Console.WriteLine("12. Optional - Swap first items between vendors");
                Console.WriteLine("13. Exit");

                Console.Write("\nEnter your choice (1-13): \n");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ServiceManager.ListAllVendors(vendors);
                        Console.WriteLine("This feature in the progress...");
                        break;

                    case "2":
                        Console.WriteLine("This feature in the progress...");
                        break;

                    case "3":
                        Console.WriteLine("This feature in the progress...");
                        break;

                    case "4":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "5":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "6":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "7":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "8":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "9":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "10":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "11":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "12":
                        Console.WriteLine("This feature in the progress...");
                        break;
                    case "13":
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 13.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

        }
    }
}