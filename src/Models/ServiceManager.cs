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

        //should be overwritten?
        public void AddVendorToListAndFile(Vendor vendor)
        {
            Vendors.Add(vendor);
            FileManager.saveInventoryToFile(Vendors);
        }

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
        public Vendor AddVendorAndInventory()
        {
            Console.Write("Enter vendor name: ");
            string? vendorName = Console.ReadLine();

            Console.Write("Enter category: ");
            string? category = Console.ReadLine();

            Console.Write("Enter condition (0.0 - 5.0): ");
            double condition = 0.0;
            bool isValidCondition = double.TryParse(Console.ReadLine(), out condition);

            // Validate the condition input
            if (!isValidCondition || condition < 0.0 || condition > 5.0)
            {
                Console.WriteLine("Invalid condition value. Defaulting to 0.0.");
                condition = 0.0;
            }

            Vendor vendor = new Vendor(vendorName);
            vendor.Inventory.Add(new Decor(condition));
            AddVendorToListAndFile(vendor);

            return vendor;
        }
    }
}