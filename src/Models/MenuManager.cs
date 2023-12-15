using System;
namespace cSharpSwapMeet
{
    public class MenuManager
    {
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
            List<Vendor> vendors = GetSampleVendors(); // Assume vendors is populated with data

            while (true)
            {
                Console.Clear(); // Clear the console for a clean menu appearance

                Console.WriteLine("Welcome to The Swapp Meet application");
                Console.WriteLine("\nMenu:\n");
                Console.WriteLine("1. List all vendors");
                Console.WriteLine("2. Add new vendor");
                Console.WriteLine("3. Get inventory listing for specific vendor");
                Console.WriteLine("4. Add item to vendor's inventory");
                Console.WriteLine("5. Remove item from vendor's inventory");
                Console.WriteLine("6. Swap items between vendors");
                Console.WriteLine("7. Get best item by category for a vendor");
                Console.WriteLine("8. Swap best items between vendors");
                Console.WriteLine("9. Add new vendor");
                Console.WriteLine("10. Change vendor name");
                Console.WriteLine("11. Check item availability");
                Console.WriteLine("12. Exit");

                Console.Write("\nEnter your choice (1-12): \n");
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
                    // .....

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

        }
    }
}