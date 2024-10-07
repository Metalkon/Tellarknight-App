using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ZSAscendedSage : Card
    {
        public ZSAscendedSage()
        {
            Name = "ZS - Ascended Sage";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 900;
            Defense = 300;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Image = "./CardArt/AscendedSage.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzWithTellar = true;
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