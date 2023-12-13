// See https://aka.ms/new-console-template for more information

namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            //create vendor withput inventory
            // var vendor1 = new Vendor("Cool Stuff");

            //to check what is printed for vendor To String Method.
            // Console.WriteLine(vendor1.VendorName);
            // vendor1.VendorName = "Anna";
            // Console.WriteLine(vendor1.VendorName);
            // Console.WriteLine(vendor1);

            Decor vase = new Decor(1);
            Console.WriteLine("vase condition: " + vase.GetConditionDescription());
            Decor wallPicture = new Decor(2);
            Decor wallMirror = new Decor(3);
            Decor table = new Decor(4);
            Electronics radio = new Electronics(5);

            Clothing dress = new Clothing(itemID: 6, condition: 4.2);
            Console.WriteLine("dress condition: " + dress.GetConditionDescription());
            Console.WriteLine("dress condition: " + dress.Condition);

            //adding item by using method Add 
            // vendor1.AddItem(vase);
            // vendor1.AddItem(wallPicture);
            // vendor1.AddItem(wallMirror);
            // vendor1.AddItem(radio);
            // vendor1.AddItem(dress);


            // List<Item> initialInventory = new List<Item> { vase, wallPicture, wallMirror, radio, dress };
            // var vendor1 = new Vendor("Jonh", initialInventory);
            // //get categoris of items in inventory
            // foreach (var item in vendor1.Inventory)
            // {
            //     Console.WriteLine(item);
            // }

            // //check if vase is available in inventory
            // if (vendor1.CheckItemAvailability(vase))
            //     Console.WriteLine($"\n{vase} is available\n");
            // else
            //     Console.WriteLine($"\n{vase} is not available\n");



            // Console.WriteLine(vendor1.CheckItemAvailability(vase)); //true
            // Console.WriteLine(vendor1.CheckItemAvailability(table)); //false
            // Console.WriteLine(vendor1.RemoveItem(new Decor(1)));//true
            // Console.WriteLine(vendor1.RemoveItem(table));//false

            // //to verify that vase is not longer available
            // if (vendor1.CheckItemAvailability(vase))
            //     Console.WriteLine($"\n{vase} is available\n");
            // else
            //     Console.WriteLine($"\n{vase} is not available\n");


            // //get categoris of items in inventory
            // foreach (var item in vendor1.Inventory)
            // {
            //     Console.WriteLine(item);
            // }

            // List<Item> newItems = [];
            // newItems = vendor1.GetItemsByCategory("Decor");
            // Console.WriteLine($"Length of new list is: {newItems.Count}");


            // //to check swiping items:
            // var vendorFriend = new Vendor("Friend");
            // var mugFriend = new Decor(8);
            // vendorFriend.Inventory.Add(mugFriend);
            // Console.WriteLine("*****************");

            // // Console.Write(vendor1.SwapItems(vendorFriend, radio, mugFriend));
            // Console.Write(vendor1.SwapFirstItems(vendorFriend));
            // foreach (var item in vendor1.Inventory)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine("*****************");
            // Console.WriteLine($"\nThis is the first item:{vendor1.Inventory[0]} in {vendor1.VendorName}");
            // Console.WriteLine($"\nThis is the first item:{vendorFriend.Inventory[0]} in {vendorFriend.VendorName}");



        }
    }
}
