using System.Reflection.Metadata.Ecma335;
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
    }
}
