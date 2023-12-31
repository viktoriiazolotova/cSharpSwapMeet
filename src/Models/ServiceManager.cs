using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

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

        // ???This method only saves data to file when all items to the vendor are added
        //refactored - removed CreateVendorFromUserInput:
        //added GetNewVendorNameFromUser instead and confirmation string

        public void AddVendorAndInventory()
        {
            string newVendorName = GetNewVendorNameFromUser();
            Vendor newVendor = new Vendor(newVendorName);

            bool wantsToAddItem;
            do
            {
                AddItemToInventory(newVendor);
                wantsToAddItem = PromptUser("Do you want to add another item? (y/n): ");
            } while (wantsToAddItem);

            AddVendorToListAndFile(newVendor);
            Console.WriteLine($"\nVendor \"{newVendor.VendorName}\" successuly added.\n{newVendor.GetVendorWithInventory()}");

        }

        public void AddItemToInventory(Vendor vendor)
        {
            string category = GetValidCategoryFromUserInput()!;
            double condition = GetConditionFromUser();
            Item newItem = CreateItemFromUserInput(category, condition)!;
            vendor.Inventory.Add(newItem);
            Console.WriteLine($"\nNew item with itemID: {newItem.ItemID} has been added.\n");
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

        //Method for menu 6 - Remove item from inventory by itemId
        public void RemoveItemFromVendorAndSaveToFile()
        {
            string vendorName = GetExistingVendorNameFromUser();
            Vendor? vendor = GetVendorByVendorName(vendorName)!;

            if (vendor.Inventory.Count == 0)
            {
                Console.WriteLine($"\nVendor {vendor.VendorName}'s inventory is empty! No items to be removed.");
                return;
            }

            bool wantsToRemoveItem;
            do
            {
                Console.WriteLine($"\nHere is the current inventory listing for vendor:\n{vendor.GetVendorWithInventory()}");
                //added this line and refactored method: GetValidItemIdFromUser
                Console.WriteLine("To remove item:");
                RemoveItemFromInventory(vendor);

                if (vendor.Inventory.Count == 0)
                {
                    Console.WriteLine($"\nVendor {vendor.VendorName}'s inventory is now empty. No more items to be removed.");
                    break;
                }

                wantsToRemoveItem = PromptUser("Do you want to remove another item? (y/n): ");
            } while (wantsToRemoveItem);

            Console.WriteLine($"\nYou have finished removing items from the inventory of vendor \"{vendor.VendorName}\".");

        }

        private void RemoveItemFromInventory(Vendor vendor)
        {
            int itemId = GetValidItemIdFromUser();
            Item? itemToRemove = GetItemByItemId(vendor, itemId);

            if (itemToRemove != null)
            {
                vendor.Inventory.Remove(itemToRemove);
                FileManager.saveInventoryToFile(Vendors);
                Console.WriteLine($"\nItem with ID {itemId} has been removed from the inventory.\n");
            }
            else
            {
                Console.WriteLine($"\nItem with ID {itemId} not found in the {vendor.VendorName}\'s inventory.\n");
            }
        }

        private int GetValidItemIdFromUser()
        {
            while (true)
            {
                //removed from string 'to remove item' to make method reusable
                Console.Write("Enter the item ID: ");
                string? itemIdInput = Console.ReadLine();

                if (int.TryParse(itemIdInput, out int itemId))
                {
                    return itemId;
                }

                Console.WriteLine("Invalid item ID. Please enter a valid integer value.");
            }
        }

        private Item? GetItemByItemId(Vendor vendor, int itemId)
        {
            /*
            This method returns Item object if it exist in Vendor inventory
            o null if no itemId found in Vendor Inventory
            */
            return vendor.Inventory.Find(item => item.ItemID == itemId);
        }

        // Method for menu #7 - Get all items by category for vendor
        public void DisplayItemsByCategoryForVendor()
        {
            string vendorName = GetExistingVendorNameFromUser();
            Vendor? vendor = GetVendorByVendorName(vendorName)!;

            if (vendor.Inventory.Count == 0)
            {
                Console.WriteLine($"\nVendor {vendor.VendorName}'s inventory is empty.");
                return;
            }

            bool continueToCheck;
            do
            {
                string category = GetValidCategoryFromUserInput()!;
                List<Item> itemsByCategory = vendor.GetItemsByCategory(category);

                if (itemsByCategory.Count > 0)
                {

                    Console.WriteLine(vendor.GetVendorWithInventory(itemsByCategory));
                }
                else
                {
                    Console.WriteLine($"\nNo items found in the category \"{category}\" for vendor \"{vendor.VendorName}\".\n");
                }
                continueToCheck = PromptUser("Would you like to check items by other category? (y/n): ");

            } while (continueToCheck);
        }

        //Method for menu 8 -CheckItemAvailabilityForVendor
        public void CheckItemAvailabilityForVendor()
        {
            string vendorName = GetExistingVendorNameFromUser();
            Vendor? vendor = GetVendorByVendorName(vendorName)!;
            bool wantToAnotherItem;
            do
            {
                int itemIdToCheck = GetValidItemIdFromUser();
                //below could be another method
                Item? itemToCheck = GetItemByItemId(vendor, itemIdToCheck);
                if (itemToCheck == null)
                {
                    Console.WriteLine($"\nItem with ID {itemIdToCheck} not found in the {vendor.VendorName}\'s inventory.\n");
                }
                else
                {
                    Console.WriteLine($"\nItem with ID {itemIdToCheck} is available in the {vendor.VendorName}\'s inventory.\n");
                }

                wantToAnotherItem = PromptUser("Would you like to check another item? (y/n): ");
            } while (wantToAnotherItem);
        }

        private Vendor? GetValidVendorWithInventory(string prompt)
        {
            Console.WriteLine(prompt);
            string vendorName = GetExistingVendorNameFromUser();
            Vendor? vendor = GetVendorByVendorName(vendorName);

            if (vendor == null || vendor.Inventory.Count == 0)
            {
                Console.WriteLine($"Selected vendor {vendor?.VendorName} has 0 items. Swap not possible. Try another vendor.");
                return null;
            }

            return vendor;
        }

        private Item? GetValidItemFromVendor(Vendor vendor, string prompt)
        {
            Item? item = null;
            bool isValidItem = false;

            while (!isValidItem)
            {
                Console.WriteLine(prompt);
                int itemId = GetValidItemIdFromUser();
                item = GetItemByItemId(vendor, itemId);

                if (item == null)
                {
                    Console.WriteLine("Item not found in the vendor's inventory. Please enter an existing item ID.\n");
                }
                else
                {
                    isValidItem = true;
                }
            }

            return item;
        }
        //Method for menu 10 - SwapItemsBetweenVendors
        public void SwapItemsBetweenVendorsAndSaveToFile()
        {
            bool wantsToContinueSwap;
            do
            {
                Vendor? sourceVendor = GetValidVendorWithInventory("Select the source vendor:");
                //need this since vendor can be null
                if (sourceVendor == null)
                {
                    return;
                }

                Vendor? targetVendor = GetValidVendorWithInventory("Select the target vendor:");
                //need this since vendor can be null
                if (targetVendor == null)
                {
                    return;
                }
                Console.WriteLine($"\nHere is the current inventory listing for vendor:\n{sourceVendor.GetVendorWithInventory()}");
                Console.WriteLine($"\nHere is the current inventory listing for vendor:\n{targetVendor.GetVendorWithInventory()}");


                Item? itemSourceVendor = GetValidItemFromVendor(sourceVendor, $"Select the item for source vendor {sourceVendor.VendorName}:")!;

                Item? itemTargetVendor = GetValidItemFromVendor(targetVendor, $"Select the item for target vendor {targetVendor.VendorName}:")!;

                sourceVendor.SwapItems(targetVendor, itemSourceVendor, itemTargetVendor);
                FileManager.saveInventoryToFile(Vendors);


                Console.WriteLine($"\nItem with ID {itemSourceVendor.ItemID} has been swapped from {sourceVendor.VendorName} to {targetVendor.VendorName}.");
                Console.WriteLine($"\nItem with ID {itemTargetVendor.ItemID} has been swapped from {targetVendor.VendorName} to {sourceVendor.VendorName}.\n");

                wantsToContinueSwap = PromptUser("Would you like to contuniue to swap? (y/n): ");

            } while (wantsToContinueSwap);
        }
    }
}