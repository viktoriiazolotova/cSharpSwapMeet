// See https://aka.ms/new-console-template for more information

namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            var vendor1 = new Vendor();

            Decor vase = new Decor(1);
            Decor wallPicture = new Decor(2, "Decor");
            Decor wallMirror = new Decor(3, "Decor");
            Decor table = new Decor(4, "Decor");

            //adding item by using method Add 
            vendor1.AddItem(vase);
            vendor1.AddItem(wallPicture);
            vendor1.AddItem(wallMirror);

            //get categoris of items in inventory
            foreach (var item in vendor1.Inventory)
            {
                Console.WriteLine(item);
            }

            //check item availability in inventory
            Console.WriteLine(vendor1.CheckItemAvailability(vase)); //true
            Console.WriteLine(vendor1.CheckItemAvailability(table)); //false
            Console.WriteLine(vendor1.RemoveItem(vase));//true
            Console.WriteLine(vendor1.RemoveItem(table));//false

            foreach (var item in vendor1.Inventory)
            {
                Console.WriteLine(item);
            }

        }
    }
}
