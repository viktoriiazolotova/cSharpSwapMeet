using System;
using System.Collections.Generic;

namespace cSharpSwapMeet
{
    public class ServiceManager
    {
        public ServiceManager()
        {
            Vendors = FileManager.ReadVendorsFromFile();
        }
        private List<Vendor> Vendors { get; }


        public void AddVendorToListAndFile(Vendor vendor)
        {
            Vendors.Add(vendor);
            FileManager.saveInventoryToFile(Vendors);
        }

        public List<string> ListAllVendorsAndInventory()
        {
            List<string> output = [];
            foreach (var vendor in Vendors)
            {
                output.Add(vendor.GetVendorWithInventory());
            }
            return output;
        }

        public void DisplayAllVendorsAndInventory()
        {
            List<string> output = ListAllVendorsAndInventory();
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }

        // public void AddVendorAndInventory()
        // {
        //     Vendor? newVendor = null;
        //     string? vendorName;
        //     string? category;
        //     double condition;
        //     bool addNewItem = true;

        //     Console.Write("Enter vendor name: ");
        //     vendorName = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(vendorName))
        //     {
        //         Console.WriteLine("Vendor name is required. Please try again.");
        //         return;
        //     }

        //     newVendor = new Vendor(vendorName);


        //     do
        //     {
        //         while (true)
        //         {
        //             Console.Write("Enter category (Decor, Clothing, Electronics): ");
        //             category = Console.ReadLine()?.Trim();

        //             if (string.IsNullOrWhiteSpace(category))
        //             {
        //                 Console.WriteLine("Category is required. Please try again.");
        //                 continue;
        //             }

        //             if (category.Equals("Decor", StringComparison.OrdinalIgnoreCase) ||
        //                 category.Equals("Clothing", StringComparison.OrdinalIgnoreCase) ||
        //                 category.Equals("Electronics", StringComparison.OrdinalIgnoreCase))
        //             {
        //                 break;
        //             }

        //             Console.WriteLine("Invalid category. Please enter a valid category.");
        //         }

        //         while (true)
        //         {
        //             Console.Write("Enter condition (0.0 - 5.0): ");
        //             string? conditionInput = Console.ReadLine();

        //             if (!double.TryParse(conditionInput, out condition) || condition < 0.0 || condition > 5.0)
        //             {
        //                 Console.WriteLine("Invalid condition value. Please enter a value between 0.0 and 5.0.");
        //                 continue;
        //             }

        //             break;
        //         }
        //         Item? newItem = null;


        //         switch (category.ToLower())
        //         {
        //             case "decor":
        //                 newItem = new Decor(condition);
        //                 break;
        //             case "electronics":
        //                 newItem = new Electronics(condition);
        //                 break;
        //             case "clothing":
        //                 newItem = new Clothing(condition);
        //                 break;
        //         }

        //         if (newItem == null)
        //         {
        //             Console.WriteLine("Unknown category. Please try again.");
        //             continue;
        //         }

        //         newVendor.Inventory.Add(newItem);

        //         Console.Write("Do you want to add another item? (y/n): ");
        //         string? readResult = Console.ReadLine()?.Trim().ToLower();

        //         addNewItem = (readResult == "y");
        //     } while (addNewItem);

        //     if (newVendor != null && newVendor.Inventory.Count > 0)
        //     {
        //         AddVendorToListAndFile(newVendor);
        //     }
        // }
        public void AddVendorAndInventory()
        {
            Vendor? newVendor = CreateVendor();
            if (newVendor == null)
            {
                return;
            }

            while (true)
            {
                string? category = GetValidCategory();
                if (category == null)
                {
                    Console.WriteLine("Unknown category. Please try again.");
                    continue;
                }

                double condition = GetConditionFromUser();

                Item? newItem = CreateItem(category, condition);
                if (newItem == null)
                {
                    Console.WriteLine("Unknown category. Please try again.");
                    continue;
                }

                newVendor.Inventory.Add(newItem);

                if (!PromptToAddAnotherItem())
                {
                    break;
                }
            }

            if (newVendor.Inventory.Count > 0)
            {
                AddVendorToListAndFile(newVendor);
            }
        }

        private Vendor? CreateVendor()
        {
            while (true)
            {
                Console.Write("Enter vendor name: ");
                string? vendorName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(vendorName))
                {
                    Console.WriteLine("Vendor name is required. Please try again.");
                    continue;
                }

                return new Vendor(vendorName);
            }
        }

        private string? GetValidCategory()
        {
            while (true)
            {
                Console.Write("Enter category (Decor, Clothing, Electronics): ");
                string? category = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(category) &&
                    (category.Equals("Decor", StringComparison.OrdinalIgnoreCase) ||
                    category.Equals("Clothing", StringComparison.OrdinalIgnoreCase) ||
                    category.Equals("Electronics", StringComparison.OrdinalIgnoreCase)))
                {
                    return category;
                }

                Console.WriteLine("Invalid category. Please enter a valid category.");
            }
        }


        private double GetConditionFromUser()
        {
            while (true)
            {
                Console.Write("Enter condition (0.0 - 5.0): ");
                string? conditionInput = Console.ReadLine();

                if (double.TryParse(conditionInput, out double condition) && condition >= 0.0 && condition <= 5.0)
                {
                    return condition;
                }

                Console.WriteLine("Invalid condition value. Please enter a value between 0.0 and 5.0.");
            }
        }

        private Item? CreateItem(string category, double condition)
        {
            switch (category.ToLower())
            {
                case "decor":
                    return new Decor(condition);
                case "electronics":
                    return new Electronics(condition);
                case "clothing":
                    return new Clothing(condition);
                default:
                    return null;
            }
        }

        private bool PromptToAddAnotherItem()
        {
            Console.Write("Do you want to add another item? (y/n): ");
            string? readResult = Console.ReadLine()?.Trim().ToLower();

            return readResult == "y";
        }

    }
}