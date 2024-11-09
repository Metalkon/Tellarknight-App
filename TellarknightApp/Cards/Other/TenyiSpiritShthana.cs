using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TenyiSpiritShthana : Card
    {
        public TenyiSpiritShthana()
        {
            Name = "Tenyi Spirit - Shthana";
            Type = "Wyrm";
            Attribute = "Water";
            Level = 4;
            Attack = 400;
            Defense = 2000;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 24557335;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzOneTellar = true;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x != this && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}