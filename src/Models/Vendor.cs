using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;


namespace cSharpSwapMeet
{
    public class Vendor
    {
        public Vendor(string vendorName, List<Item>? inventory = null)
        {
            VendorName = vendorName;
            Inventory = inventory ?? new List<Item>();
        }
        public string VendorName { get; set; }
        public List<Item> Inventory { get; set; } = [];

        public override string ToString()
        {
            return $"Vendor name is: {VendorName}.";
        }


        public bool AddItem(Item item)
        {
            Inventory.Add(item);
            return true;
        }

        public bool CheckItemAvailability(Item item)
        {
            foreach (var inventoryItem in Inventory)
            {
                if (item.ItemID == inventoryItem.ItemID)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        //shorter way
        // public bool CheckItemAvailability(Item item)
        // {
        //     return Inventory.Any(inventoryItem => item.ItemID == inventoryItem.ItemID);
        // }

        public bool RemoveItem(Item item)
        {
            if (CheckItemAvailability(item))
            {
                Inventory.Remove(item);
                return true;
            }
            return false;
        }

        public List<Item> GetItemsByCategory(string category)
        {
            List<Item> ItemsByCategory = new();
            foreach (var item in Inventory)
            {
                if (item.Category == category)
                {
                    ItemsByCategory.Add(item);
                }

            }
            return ItemsByCategory;
        }
        //refactoring using LINQ
        // public List<Item> GetItemsByCategory(string category)
        // {
        //     return Inventory.Where(item => item.Category == category).ToList();
        // }
        public string SwapItems(Vendor swappedVendor, Item myItem, Item theirItem)
        {
            string result = "";
            if (swappedVendor.RemoveItem(theirItem) && this.RemoveItem(myItem))
            {
                this.AddItem(theirItem);
                swappedVendor.AddItem(myItem);
                result = "You successfully swapped items";
                return result;

            };
            result = "Swapping items was unsuccessful, please check inventory";
            return result;
        }

        public string SwapFirstItems(Vendor swappedVendor)
        {
            string result = "";
            if (Inventory.Count == 0 || swappedVendor.Inventory.Count == 0)
            {
                result = "Swapping items was unsuccessful, one of the vendor does not have inventory";
            }
            else
            {
                result = this.SwapItems(swappedVendor, Inventory[0], swappedVendor.Inventory[0]);

            }
            return result;
        }

        public Item? GetBestByCategory(string category)
        {
            /*
            Returns the best first item by category or null if there are no items in that category.
            */

            // Check if the vendor has any items
            if (Inventory.Count == 0)
            {
                return null;
            }

            List<Item> itemsByCategory = GetItemsByCategory(category);

            if (itemsByCategory.Count == 0)
            {
                return null;
            }

            Item bestItem = itemsByCategory[0];
            foreach (var item in itemsByCategory)
            {
                if (item.Condition > bestItem.Condition)
                {
                    bestItem = item;
                }
            }
            return bestItem;
            // Use LINQ to find the item with the maximum condition
            // Item? bestItem = itemsByCategory.OrderByDescending(item => item.Condition).FirstOrDefault();
            // return bestItem;
        }

        public bool SwapBestByCategory(Vendor swappedVendor, string myPriority, string theirPriority)
        {
            Item? myBestItemByCategory = this.GetBestByCategory(theirPriority);
            Item? theirBestItemByCategory = swappedVendor.GetBestByCategory(myPriority);

            if (myBestItemByCategory != null && theirBestItemByCategory != null)
            {
                SwapItems(swappedVendor, myBestItemByCategory, theirBestItemByCategory);
                return true;
            }

            return false;
        }
        public string GetVendorWithInventory()
        {
            string inventoryString = string.Join("", Inventory.Select(item =>
                $"Category: {item.Category},\titemID: {item.ItemID}, condition: {item.Condition}\n"));

            return $"{VendorName}:\n{inventoryString}";
        }
    }
}
