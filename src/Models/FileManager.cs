using System;
using System.Collections.Generic;
using System.IO;

namespace cSharpSwapMeet
{
    public class FileManager
    {
        private const string DefaultFilePath = "inventory.txt";

        public static List<Vendor> ReadVendorsFromFile(string filePath = DefaultFilePath)
        {
            List<Vendor> vendors = new List<Vendor>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');

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
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return vendors;
        }

        public static void saveInventoryToFile(List<Vendor> vendors, string filePath = DefaultFilePath)
        {
            try
            {

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var vendor in vendors)
                    {
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