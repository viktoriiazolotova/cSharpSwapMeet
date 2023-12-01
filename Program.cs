// See https://aka.ms/new-console-template for more information

namespace cSharpSwapMeet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            // Vendor.VendorMethod();
            var vendor1 = new Vendor();
            Decor vase = new Decor(1, "Decor");
            Decor wallPicture = new Decor(2, "Decor");
            Decor wallMirror = new Decor(3, "Decor");
            //one way to add
            // vendor1.Inventory.Add(new Decor(1, "Decor"));
            //second way to add
            vendor1.Inventory.Add(vase);
            vendor1.Inventory.Add(wallPicture);
            vendor1.Inventory.Add(wallMirror);

            //get categoris of items in inventory
            foreach (var item in vendor1.Inventory)
            {
                Console.WriteLine(item);
            }

        }
    }
}
