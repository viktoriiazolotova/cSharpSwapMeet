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
            Console.WriteLine("New vendor added to the file successfully.");
        }

        //methods for menu #1
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

        //methods for menu #2
        public void AddVendorAndInventory()
        {
            Vendor? newVendor = CreateVendorFromUserInput();
            if (newVendor == null)
            {
                return;
            }

            while (true)
            {
                string? category = GetValidCategoryFromUserInput();
                if (category == null)
                {
                    Console.WriteLine("Unknown category. Please try again.");
                    continue;
                }

                double condition = GetConditionFromUser();

                Item? newItem = CreateItemFromUserInput(category, condition);
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

        public Vendor? CreateVendorFromUserInput()
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

        private string? GetValidCategoryFromUserInput()
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

        private Item? CreateItemFromUserInput(string category, double condition)
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

        //methods for menu #3
        public Vendor? GetVendorByVendorName(string vendorNameFromUser)
        {
            return Vendors.Find(vendor => vendor.VendorName == vendorNameFromUser);
        }

        public bool IsVendorNameAlreadyExists(string vendorName)
        {
            return Vendors.Any(vendor => vendor.VendorName.Equals(vendorName, StringComparison.OrdinalIgnoreCase));
        }

        public string GetExistingVendorNameFromUser()
        {
            string? vendorName;
            do
            {
                Console.Write("Enter the vendor name (case sensitive): ");
                vendorName = Console.ReadLine();
            } while (string.IsNullOrEmpty(vendorName));

            return vendorName;
        }

        public string GetNewVendorNameFromUser()
        {
            string? newVendorName;
            do
            {
                Console.Write("Enter the new vendor name: ");
                newVendorName = Console.ReadLine();

                if (newVendorName != null)
                {
                    if (IsVendorNameAlreadyExists(newVendorName))
                    {
                        Console.WriteLine("Vendor name already exists. Please enter a different name.");
                        newVendorName = null;
                    }
                }

            } while (string.IsNullOrEmpty(newVendorName));

            return newVendorName;
        }

        public void ChangeVendorNameAndSaveToFile()
        {
            string vendorNameFromUser = GetExistingVendorNameFromUser();

            Vendor? vendor = GetVendorByVendorName(vendorNameFromUser);
            if (vendor != null)
            {
                string newVendorName = GetNewVendorNameFromUser();

                vendor.VendorName = newVendorName;
                FileManager.saveInventoryToFile(Vendors);

                Console.WriteLine("Vendor name changed successfully.");
            }
            else
            {
                Console.WriteLine("Vendor not found. Please check vendor name and try again.");
            }
        }

        //methods for menu #4
        public void GetInventoryListingForVendor()
        {
            string vendorName = GetExistingVendorNameFromUser();
            Vendor? vendor = GetVendorByVendorName(vendorName);

            if (vendor != null)
            {
                Console.WriteLine(vendor.GetVendorWithInventory());
            }
            else
            {
                Console.WriteLine("Vendor not found.");
            }
        }


    }
}