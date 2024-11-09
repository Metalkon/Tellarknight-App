using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class VanquishSoulPantera : Card
    {
        public VanquishSoulPantera()
        {
            Name = "Vanquish Soul Pantera";
            Type = "Beast-Warrior";
            Attribute = "Earth";
            Level = 4;
            Attack = 1700;
            Defense = 1900;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 66401502;
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