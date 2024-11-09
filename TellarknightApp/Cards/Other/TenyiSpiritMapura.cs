using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TenyiSpiritMapura : Card
    {
        public TenyiSpiritMapura()
        {
            Name = "Tenyi Spirit - Mapura";
            Type = "Wyrm";
            Attribute = "Fire";
            Level = 4;
            Attack = 600;
            Defense = 1500;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 60942444;
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