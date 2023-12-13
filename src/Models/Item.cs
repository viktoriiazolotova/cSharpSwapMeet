using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace cSharpSwapMeet
{
    public abstract class Item
    {
        protected Item(int itemID, string category, int condition = 0)
        {
            ItemID = itemID;
            Category = category;
            Condition = condition;
        }

        public int ItemID { get; set; }
        public string Category { get; set; }

        public int Condition { get; set; }


        public override string ToString()
        {
            return $"This item with ID {ItemID} belongs to the category of {Category}";
        }

        public string GetConditionDescription()
        {
            if (Condition <= 1)
            {
                return "Heavily Used";
            }
            else if (Condition <= 2)
            {
                return "Fair condition";
            }
            else if (Condition <= 3)
            {
                return "Good condition";
            }
            else if (Condition <= 4)
            {
                return "Normal condition";
            }
            else
            {
                return "Excellent condition";
            }
        }


    }
}