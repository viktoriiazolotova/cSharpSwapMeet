// See https://aka.ms/new-console-template for more information
using System;


namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager newMenuManager = new MenuManager();
            newMenuManager.RunMenu();




            // FileManager.AddOrUpdateVendorToFile(testVendor, "inventory.txt");


            // var testJonh = new Vendor("John1");
            // // var decor1 = new Decor();
            // // testJonh.AddItem(decor1);
            // // var radio1 = new Electronics(condition: 5.0);
            // // testJonh.AddItem(radio1);
            // string output = testJonh.GetVendorWithInventory();
            // Console.WriteLine(output);


            // FileManager.AddOrUpdateVendorToFile(testJonh, "inventory.txt");
            // var vika = new Vendor("Vika");
            // var mug = new Decor(condition: 4.0);var testVendor = new Vendor("Test");
            // var item3 = new Decor();
            // testVendor.AddItem(item3);
            // var item4 = new Decor();
            // testVendor.AddItem(item4);
            // ServiceManager newServiceManager = new ServiceManager();
            // newServiceManager.addVendor(testVendor);
            // vika.AddItem(mug);
            // FileManager.AddOrUpdateVendorToFile(vika, "inventory.txt");
            // FileManager.AddOrUpdateVendorToFile(new Vendor("Vendor1"), "inventory.txt");
            // // Auto-generated itemID
            // Decor item1 = new Decor();
            // Console.WriteLine(item1.ItemID);  // Output: 1

            // Decor item4 = new Decor(condition: 5.0);
            // Console.WriteLine(item4.ItemID);
            // Console.WriteLine(item4.Condition);  // Output: 2

            // // // Explicitly specified itemID
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