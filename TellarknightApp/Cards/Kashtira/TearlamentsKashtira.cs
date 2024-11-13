using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TearlamentsKashtira : Card
    {
        public TearlamentsKashtira()
        {
            Name = "Tearlaments Kashtira";
            Type = "Water";
            Attribute = "Psychic";
            Level = 7;
            Attack = 2300;
            Defense = 1200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 04928565;
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