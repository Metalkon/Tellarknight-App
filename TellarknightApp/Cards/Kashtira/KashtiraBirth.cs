using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class KashtiraBirth : Card
    {
        public KashtiraBirth()
        {
            Name = "Kashtira Birth";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 69540484;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if ((hand.Count(x => x.Archetype.Contains("Kashtira") && x.Level == 7) >= 2
                && hand.Count(x => x.Archetype.Contains("Kashtira") && x.Level != null) >= 3)
                && hand.Any(x => x.Level == 4)
                && extraDeck.Any(x => x is RaidraptorArsenalFalcon) && deck.Any(x => x is BlackwingZephyrostheElite))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}