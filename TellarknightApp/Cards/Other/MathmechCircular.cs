using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MathmechCircular : Card
    {
        public MathmechCircular()
        {
            Name = "Mathmech Circular";
            Type = "Cyberse";
            Attribute = "Light";
            Level = 4;
            Attack = 1500;
            Defense = 1500;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Mathmech" };
            Id = 36521307;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))) && deck.Any(x => x is not MathmechCircular && x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                localStats.AverageXyzOneTellar = true;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x != this && x.Level == 4) && deck.Any(x => x is not MathmechCircular && x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}