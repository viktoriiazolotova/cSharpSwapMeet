// namespace cSharpSwapMeet
// {
//     public class Electronics(string category = "Electronics", double condition = 0.0) : Item(category, condition)
//     {

//     }
// }

namespace cSharpSwapMeet
{
    public class Electronics : Item
    {
        public Electronics(double condition = 0.0) : base("Electronics", condition)
        {

        }

        // Constructor for auto-generated ItemID
        public Electronics(int itemId, double condition) : base(itemId, "Electronics", condition)
        {

        }
    }
}