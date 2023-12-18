// See https://aka.ms/new-console-template for more information
using System;


namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            // FileManager.ReadVendorsFromFile("inventory.txt");
            MenuManager.DisplayMenu();

            // var testVendor = new Vendor("John");
            // var item1 = new Decor();
            // testVendor.AddItem(item1);
            // // FileManager.AddNewVendorToFile(testVendor, "inventory.txt");

            // FileManager.AddOrUpdateVendorToFile(testVendor, "inventory.txt");


            // var testJonh = new Vendor("John1");
            // var decor1 = new Decor();
            // testJonh.AddItem(decor1);
            // var radio1 = new Electronics(condition: 5.0);
            // testJonh.AddItem(radio1);


            // FileManager.AddOrUpdateVendorToFile(testJonh, "inventory.txt");
            // var vika = new Vendor("Vika");
            // var mug = new Decor(condition: 4.0);
            // vika.AddItem(mug);
            // FileManager.AddOrUpdateVendorToFile(vika, "inventory.txt");
            // FileManager.AddOrUpdateVendorToFile(new Vendor("Vendor1"), "inventory.txt");
            // // Auto-generated itemID
            // Decor item1 = new Decor();
            // Console.WriteLine(item1.ItemID);  // Output: 1

            // Decor item4 = new Decor(condition: 5.0);
            // Console.WriteLine(item4.ItemID);
            // Console.WriteLine(item4.Condition);  // Output: 2

            // // Explicitly specified itemID
            // Decor item5 = new Decor(6, condition: 3.0);
            // Console.WriteLine(item5.ItemID);  // Output: 6
            // Console.WriteLine(item5.Condition);  // Output: 6

            // var item2 = new Electronics();
            // Console.WriteLine(item1.ItemID);
            // var item3 = new Clothing();
            // Console.WriteLine(item1.ItemID);

        }

    }
}