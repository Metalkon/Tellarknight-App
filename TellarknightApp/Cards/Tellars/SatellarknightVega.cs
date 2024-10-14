using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightVega : Card
    {
        public SatellarknightVega() 
        {
            Name = "Satellarknight Vega";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Vega.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Vega + Any Other Lv4 Tellarknight
            if (hand.Any(x => x is not SatellarknightVega && x.Level == 4 && x.Archetype.Contains("Tellarknight")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}