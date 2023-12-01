using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace cSharpSwapMeet
{
    public class Vendor
    {
        public List<Item> Inventory { get; set; } = new();
        public void AddItem(Item item)
        {
            Console.WriteLine("This is inside of the vendor class");
            Inventory.Add(item);
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

        // this method can only return one of data - Item or Bool, 
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
    }
}