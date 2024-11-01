using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class IgnisPhoenixTheDracoslayer : Card
    {
        public IgnisPhoenixTheDracoslayer()
        {
            Name = "Ignis Phoenix, the Dracoslayer";
            Type = "Warrior";
            Attribute = "Fire";
            Level = 4;
            Attack = 1700;
            Defense = 1900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 56347375;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}