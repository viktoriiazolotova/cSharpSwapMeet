// VendorService.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpSwapMeet
{
    public class ServiceManager
    {

        public static void ListAllVendors(List<Vendor> vendors)
        {
            Console.WriteLine("\nList of all vendors:");

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"- {vendor.VendorName}");
                foreach (var item in vendor.Inventory)
                {
                    Console.WriteLine($"\n{item.ToString()}");
                    Console.WriteLine($"\nItem Id#: {item.ItemID}");
                    Console.WriteLine($"Item category: {item.Category}");
                    Console.WriteLine($"Item condition: {item.Condition}\n");
                }
            }
        }
    }
}
