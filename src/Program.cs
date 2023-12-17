// See https://aka.ms/new-console-template for more information
using System;


namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileManager.ReadVendorsFromFile("inventory.txt");
            MenuManager.DisplayMenu();


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