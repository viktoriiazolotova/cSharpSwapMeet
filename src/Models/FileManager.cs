using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace cSharpSwapMeet
{
    public class FileManager
    {

        private const string DefaultFilePath = "inventory.txt";

        private static List<Vendor> vendors = new List<Vendor>();

        public static List<Vendor> ReadVendorsFromFile(string filePath = DefaultFilePath)
        {

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] parts = line.Split('|');

                        // Parse the data and create Vendor and Item instances
                        // Add them to the vendors list
                        Vendor vendor = new Vendor(parts[0]);
                        for (int i = 1; i < parts.Length; i += 3)
                        {
                            int itemId = int.Parse(parts[i]);
                            string category = parts[i + 1];
                            double condition = double.Parse(parts[i + 2]);

                            Item item;
                            switch (category)
                            {
                                case "Decor":
                                    item = new Decor(itemId, condition);
                                    break;
                                case "Electronics":
                                    item = new Electronics(itemId, condition);
                                    break;
                                case "Clothing":
                                    item = new Clothing(itemId, condition);
                                    break;
                                default:
                                    throw new InvalidOperationException($"Unknown category: {category}");
                            }
                            vendor.AddItem(item);
                        }
                        vendors.Add(vendor);
                    }
                }

                Console.WriteLine("Vendors read from file successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Creating a new file for vendors.");
                // WriteVendorsToFile(); // You may want to uncomment this line if you want to create a new file here.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return vendors;
        }
        //not tested yet
        public static void AddOrUpdateVendorToFile(Vendor vendorToAdd, string filePath = DefaultFilePath)
        {
            try
            {
                List<Vendor> vendorsFromFile = ReadVendorsFromFile(filePath);

                vendorsFromFile.Add(vendorToAdd);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var vendor in vendorsFromFile)
                    {
                        // Write the vendor's data to the file
                        writer.Write($"{vendor.VendorName}");

                        foreach (var item in vendor.Inventory)
                        {
                            writer.Write($"|{item.ItemID}|{item.Category}|{item.Condition}");
                        }

                        writer.WriteLine();
                    }
                }

                Console.WriteLine("New vendor added to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}