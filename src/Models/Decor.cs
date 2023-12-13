using System.ComponentModel;

namespace cSharpSwapMeet
{
    public class Decor(int itemID, string category = "Decor", double condition = 0.0) : Item(itemID, category, condition)
    {

    }
}