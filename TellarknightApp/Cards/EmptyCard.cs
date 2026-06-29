using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class EmptyCard : Card
    {
        public EmptyCard()
        {
            Name = "Placeholder Card";
            Image = "./CardArt/Placeholder.jpg";
        }

        public override Card Clone()
        {
            return this;
        }
    }
}