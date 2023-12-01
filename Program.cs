// See https://aka.ms/new-console-template for more information

namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            var vendor1 = new Vendor("Cool Stuff");
            //to check what is printed for vendor To String Method.
            Console.WriteLine(vendor1);

            Decor vase = new Decor(1);
            Decor wallPicture = new Decor(2);
            Decor wallMirror = new Decor(3);
            Decor table = new Decor(4);
            Electronics radio = new Electronics(5);
            Clothing dress = new Clothing(6);

            //adding item by using method Add 
            vendor1.AddItem(vase);
            vendor1.AddItem(wallPicture);
            vendor1.AddItem(wallMirror);
            vendor1.AddItem(radio);
            vendor1.AddItem(dress);


            //get categoris of items in inventory
            foreach (var item in vendor1.Inventory)
            {
                Console.WriteLine(item);
            }

            //check if vase is available in inventory
            if (vendor1.CheckItemAvailability(vase))
                Console.WriteLine($"\n{vase} is available\n");
            else
                Console.WriteLine($"\n{vase} is not available\n");



            Console.WriteLine(vendor1.CheckItemAvailability(vase)); //true
            Console.WriteLine(vendor1.CheckItemAvailability(table)); //false
            Console.WriteLine(vendor1.RemoveItem(vase));//true
            Console.WriteLine(vendor1.RemoveItem(table));//false

            //to verify that vase is not longer available
            if (vendor1.CheckItemAvailability(vase))
                Console.WriteLine($"\n{vase} is available\n");
            else
                Console.WriteLine($"\n{vase} is not available\n");


            //get categoris of items in inventory
            foreach (var item in vendor1.Inventory)
            {
                Console.WriteLine(item);
            }

        }
    }
}
