using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class EmptyCard : Card
    {
        public EmptyCard()
        {
            Name = "Empty/Blank/Filler Card";
        }

        public override Card Clone()
        {
            return this;
        }
    }
}