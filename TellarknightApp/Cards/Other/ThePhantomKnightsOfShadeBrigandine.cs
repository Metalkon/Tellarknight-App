using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ThePhantomKnightsOfShadeBrigandine : Card
    {
        public ThePhantomKnightsOfShadeBrigandine() 
        {
            Name = "The Phantom Knights of Shade Brigandine";
            Type = "Trap";
            Attribute = null;
            Level = 4;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Image = "./CardArt/Brigandine.png";
            Id = 98827725;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x is not ThePhantomKnightsOfShadeBrigandine && x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzOneTellar = true;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x is not ThePhantomKnightsOfShadeBrigandine && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}