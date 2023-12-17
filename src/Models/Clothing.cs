// namespace cSharpSwapMeet
// {
//     public class Clothing(string category = "Clothing", double condition = 0.0) : Item(category, condition)
//     {

//     }
// }

namespace cSharpSwapMeet
{
    public class Clothing : Item
    {
        public Clothing(double condition = 0.0) : base("Clothing", condition)
        {

        }

        // Constructor for auto-generated ItemID
        public Clothing(int itemId, double condition) : base(itemId, "Clothing", condition)
        {

        }
    }
}
