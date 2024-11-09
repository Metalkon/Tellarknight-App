using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ZSArmedSage : Card
    {
        public ZSArmedSage()
        {
            Name = "ZS - Armed Sage";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 300;
            Defense = 900;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 68258355;
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
            if (hand.Any(x => x is not ZSArmedSage && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}