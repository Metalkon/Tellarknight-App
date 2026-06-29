using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class GagagagaMagician : Card
    {
        public GagagagaMagician()
        {
            Name = "Gagagaga Magician";
            Type = "Spellcaster";
            Attribute = "Dark";
            Level = 4;
            Attack = 2000;
            Defense = 2000;
            Scale = null;
            Role = "Extra Deck";
            Archetype = new List<string> { "Onomat", "Gagaga" };
            Id = 86331741;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}