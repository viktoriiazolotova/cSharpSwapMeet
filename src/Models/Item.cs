using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace cSharpSwapMeet
{
    public abstract class Item
    {
        private static int s_itemCount = 0;
        private static readonly object lockObject = new object();
        protected Item(string category, double condition = 0.0)
        {
            // ItemID = itemID;
            lock (lockObject)
            {
                ItemID = ++s_itemCount;
            }

            Category = category;
            Condition = condition;
        }


        public int ItemID { get; private set; }
        public string Category { get; set; }

        public double Condition { get; set; }


        public override string ToString()
        {
            return $"This item with ID {ItemID} belongs to the category of {Category}";
        }

        public string GetConditionDescription()
        {
            if (Condition <= 1)
            {
                return "Heavily used";
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