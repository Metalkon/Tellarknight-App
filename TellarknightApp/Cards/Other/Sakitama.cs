using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Sakitama : Card
    {
        public Sakitama()
        {
            Name = "Sakitama";
            Type = "Fairy";
            Attribute = "Light";
            Level = 4;
            Attack = 400;
            Defense = 900;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 67972302;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzOneTellar = true;
                return localStats;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x != this && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}