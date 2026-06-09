using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class GagagagaGirl : Card
    {
        public GagagagaGirl()
        {
            Name = "Gagagaga Girl";
            Type = "Spellcaster";
            Attribute = "Dark";
            Level = 4;
            Attack = 1500;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat" };
            Id = 88917691;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}