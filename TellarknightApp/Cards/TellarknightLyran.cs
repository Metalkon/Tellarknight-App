using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class TellarknightLyran : Card
    {
        public TellarknightLyran() 
        {
            Name = "Tellarknight Lyran";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Image = "./CardArt/Lyran.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}

/*
 

                if (hand.Any(x => x.Name == "Tellarknight Lyran") && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") >= 1)
                {
                    localStats.AverageXyzSpellOrAltairan = true;
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Where(x => x.Name == "Tellarknight Lyran").Count() >= 2
                    && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") == 0
                    && ((hand.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights"))))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Vega") && CountCards(hand, "Satellarknight Vega", 4, "Tellarknight") >= 1)
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Caduceus") && CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan") && (CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1 || (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2))
                    && (deck.Any(x => x.Name == "Constellar Caduceus") || deck.Any(x => x.Name == "Constellar Caduceus"))
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Living Fossil")
                    && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
                {
                    // Assuming altairan is sent, may need more specific dontiions in future
                    localStats.AverageXyzSpellOrAltairan = true;
                    localStats.AverageXyzTwoTellars = true;
                }

                // Constellar-Specific Monster Effects
                if (hand.Any(x => (x.Name == "Constellar Pollux" || x.Name == "Constellar Algiedi")) && hand.Count(x => x.Archetype.Contains("Constellar") && x.Level == 4) >= 2)
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan")
                    && (deck.Any(x => x.Name == "Constellar Twinkle") || hand.Any(x => x.Name == "Constellar Twinkle"))
                    && (deck.Any(x => x.Name == "Constellar Caduceus" && x.Level == 4) || hand.Any(x => x.Name == "Constellar Caduceus")))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
            }

 */