// InventoryService.cs
using System;
using System.Collections.Generic;

namespace cSharpSwapMeet
{
    public class InventoryService
    {
        public static void GetInventoryListing(List<Vendor> vendors)
        {
            Console.Write("\nEnter the name of the vendor: ");
            string? vendorName = Console.ReadLine();

            var vendor = vendors.FirstOrDefault(v => v.VendorName.Equals(vendorName, StringComparison.OrdinalIgnoreCase));

            if (vendor != null)
            {
                Console.WriteLine($"\nInventory listing for {vendor.VendorName}:");
                foreach (var item in vendor.Inventory)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("Vendor not found.");
            }
        }
    }
}
