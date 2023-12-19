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

        public void addVendor(Vendor vendor)
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
    }
}