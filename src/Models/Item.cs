using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace cSharpSwapMeet
{
    public abstract class Item
    {
        // private static int s_itemCount = 0;
        private static readonly Random random = new Random();
        private static readonly object lockObject = new object();
        protected Item(int itemID, string category, double condition = 0.0)
        {
            ItemID = itemID;
            Category = category;
            Condition = condition;
        }
        protected Item(string category, double condition = 0.0)
        {
            {
                lock (lockObject)
                {
                    ItemID = GenerateRandomItemId();
                }
            }

            Category = category;
            Condition = condition;
        }

        public int ItemID { get; private set; }
        public string Category { get; set; }

        public double Condition { get; set; }


        public override string ToString()
        {
            return $"Category: {Category},\titemID: {ItemID},\tcondition: {Condition}\n";
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

        private int GenerateRandomItemId()
        {
            const int minId = 1;
            const int maxId = 1000000;

            double randomFactor = random.NextDouble() * (maxId - minId) + minId;
            return (int)Math.Round(randomFactor);
        }
    }
}