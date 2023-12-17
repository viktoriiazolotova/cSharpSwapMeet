
namespace cSharpSwapMeet
{
    public class Decor : Item
    {
        public Decor(double condition = 0.0) : base("Decor", condition)
        {

        }

        // Constructor for auto-generated ItemID
        public Decor(int itemId, double condition) : base(itemId, "Decor", condition)
        {

        }
    }
}
