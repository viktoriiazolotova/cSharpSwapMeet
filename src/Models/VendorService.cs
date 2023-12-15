// VendorService.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpSwapMeet
{
    public class VendorService
    {
        public static void ListAllVendors(List<Vendor> vendors)
        {
            Console.WriteLine("\nList of all vendors:");
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"- {vendor.VendorName}");
            }
        }
    }
}
