using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ScareclawKashtira : Card
    {
        public ScareclawKashtira()
        {
            Name = "Scareclaw Kashtira";
            Type = "Earth";
            Attribute = "Psychic";
            Level = 7;
            Attack = 0;
            Defense = 2600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 78534861;
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