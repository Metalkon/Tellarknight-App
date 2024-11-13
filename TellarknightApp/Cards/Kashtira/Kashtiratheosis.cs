using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Kashtiratheosis : Card
    {
        public Kashtiratheosis()
        {
            Name = "Kashtiratheosis";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 34447918;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}