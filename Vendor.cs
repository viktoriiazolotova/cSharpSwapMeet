using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace cSharpSwapMeet
{
    public class Vendor
    {
        public Vendor(string vendorName)
        {
            VendorName = vendorName;
        }
        public string VendorName { get; set; }

        public override string ToString()
        {
            return $"Vendor name is: {VendorName}.";
        }
        public List<Item> Inventory { get; set; } = new();
        public void AddItem(Item item)
        {
            Inventory.Add(item);
            //return item;
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

        //this method can only return one of data - Item or Bool, 
        //needs to think how to improve
        public bool RemoveItem(Item item)
        {
            if (CheckItemAvailability(item))
            {
                Inventory.Remove(item);
                return true;
            }
            return false;
        }

        //other way - to discuss
        // public void RemoveItem(Item item)
        // {
        //     if (CheckItemAvailability(item))
        //     {
        //         Inventory.Remove(item);
        //     }
        // }
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

    }
}