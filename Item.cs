using System.Dynamic;
using System.Runtime.CompilerServices;

namespace cSharpSwapMeet
{
    public abstract class Item
    {
        protected Item(int itemID, string category)
        {
            ItemID = itemID;
            Category = category;
        }

        public int ItemID { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"This item with ID {ItemID} belongs to the category of {Category}";
        }
    }
}