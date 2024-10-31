using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class TenyiSpiritNahata : Card
    {
        public TenyiSpiritNahata()
        {
            Name = "Tenyi Spirit - Nahata";
            Type = "Wyrm";
            Attribute = "Wind";
            Level = 4;
            Attack = 800;
            Defense = 1000;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 97036149;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
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