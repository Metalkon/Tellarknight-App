using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonTrueAwakening : Card
    {
        public CenturIonTrueAwakening()
        {
            Name = "Centur-Ion True Awakening";
            Type = "Trap";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 77543769;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}