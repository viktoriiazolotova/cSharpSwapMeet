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

        // ???This method only saves data to file when all items to teh vendor are added

        public void AddVendorAndInventory()
        {
            Vendor? newVendor = CreateVendorFromUserInput()!;

            bool wantsToAddItem;
            do
            {
                AddItemToInventory(newVendor);

                wantsToAddItem = PromptUser("Do you want to add another item? (y/n): ");
            } while (wantsToAddItem);

            AddVendorToListAndFile(newVendor);
        }

        public void AddItemToInventory(Vendor vendor)
        {
            string category = GetValidCategoryFromUserInput()!;
            double condition = GetConditionFromUser();
            Item newItem = CreateItemFromUserInput(category, condition)!;
            vendor.Inventory.Add(newItem);
            Console.WriteLine($"\nNew item with itemID: {newItem.ItemID} has been added.\n");
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

                return new Vendor(vendorName.ToLower());
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

        public bool PromptUser(string promptMessage)
        {
            string? readResult;
            bool validInput = false;

            do
            {
                Console.Write(promptMessage);
                readResult = Console.ReadLine()?.Trim().ToLower();

                if (readResult == "y" || readResult == "n")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            } while (!validInput);

            return readResult == "y";
        }

        //methods for menu #3
        public Vendor? GetVendorByVendorName(string vendorNameFromUser)
        {
            /*
            The method searches the Vendors list and returns
            the first Vendor object that matches the specified condition.
            If a match is found, it returns the Vendor object. Otherwise, it returns null.
            */
            return Vendors.Find(vendor => vendor.VendorName == vendorNameFromUser);
        }

        //still need to do: add this method to validate in option 2
        public bool IsVendorNameAlreadyExists(string vendorName)
        {
            return Vendors.Any(vendor => vendor.VendorName.Equals(vendorName, StringComparison.OrdinalIgnoreCase));
        }

        //refactored this one by checking if vendor exist
        public string GetExistingVendorNameFromUser()
        {
            string? vendorName;
            do
            {
                Console.Write("Enter the vendor name: ");
                vendorName = Console.ReadLine();
                if (vendorName != null)
                {
                    if (!IsVendorNameAlreadyExists(vendorName.ToLower()))
                    {
                        Console.WriteLine("Vendor name does not found. Please try again.");
                        vendorName = null;
                    }
                }
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
                    if (IsVendorNameAlreadyExists(newVendorName.ToLower()))
                    {
                        Console.WriteLine("Vendor name already exists. Please enter a different name.");
                        newVendorName = null;
                    }
                }

            } while (string.IsNullOrEmpty(newVendorName));

            return newVendorName.ToLower();
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

                Console.WriteLine($"Vendor name \"{vendorNameFromUser}\" changed successfully to the new name: \"{newVendorName}\".");
            }
        }

        //methods for menu #4
        public void GetInventoryListingForVendor()
        {

            bool wantsToContinue;
            do
            {
                string vendorName = GetExistingVendorNameFromUser();
                Vendor? vendor = GetVendorByVendorName(vendorName);
                if (vendor != null)
                {
                    Console.WriteLine("\n" + vendor.GetVendorWithInventory());
                }
                else
                {
                    Console.WriteLine("Vendor not found.");
                }
                wantsToContinue = PromptUser("Do you want to get inventory for another vendor? (y/n): ");
            } while (wantsToContinue);
        }

        //method #5 -  Add an item to the vendor's inventory

        public void AddItemToInventoryForVendorAndSaveToFile()
        {
            /*
            This method updates file every time new item has been added
            */
            string vendorNameFromUser = GetExistingVendorNameFromUser();

            Vendor? vendor = GetVendorByVendorName(vendorNameFromUser)!;
            bool wantsToAddItem;
            do
            {
                AddItemToInventory(vendor);
                FileManager.saveInventoryToFile(Vendors);

                wantsToAddItem = PromptUser("Do you want to add another item? (y/n): ");
            } while (wantsToAddItem);


            Console.WriteLine($"\nHere is the updated inventory listing for vendor:\n{vendor.GetVendorWithInventory()}");

        }




    }
}