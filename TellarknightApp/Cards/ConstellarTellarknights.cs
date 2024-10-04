using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarTellarknights : Card
    {
        public ConstellarTellarknights() 
        {
            Name = "Constellar Tellarknights";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Image = "./CardArt/ConstellarTellarknights.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            // Any 2 Tellars
            if (hand.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4))
            {
                localStats.AverageXyzTwoTellars = true;
                return localStats;
            }
            // Unuk Revive (Also Skybridge)
            if ((hand.Any(x => x is SatellarknightUnukalhai)
                || (hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) && hand.Any(x => x is SatellarknightSkybridge) && deck.Any(x => x is SatellarknightUnukalhai)))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightUnukalhai))
            {
                localStats.AverageXyzTwoTellars = true;
                return localStats;
            }
            // Deneb Search (Also Skybridge)
            if ((hand.Any(x => x is SatellarknightDeneb) 
                || (hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) && hand.Any(x => x is SatellarknightSkybridge) && deck.Any(x => x is SatellarknightDeneb)))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb))
            {
                localStats.AverageXyzTwoTellars = true;
                return localStats;
            }

            // Tellar + Random Level 4

            return localStats;
        }
    }
}