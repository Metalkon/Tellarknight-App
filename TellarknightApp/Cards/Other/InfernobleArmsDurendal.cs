using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class InfernobleArmsDurendal : Card
    {
        public InfernobleArmsDurendal() 
        {
            Name = "\"Infernoble Arms - Durendal\"";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 37478723;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Two Warriors and FireFlint(Deck)
            if (hand.Count(x => x.Level == 4 && x.Type == "Warrior") >= 2 && deck.Any(x => x is FireFlintLady))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Count(x => x.Level == 4 && x.Type == "Warrior" && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))) >= 2)
                {
                    localStats.AverageXyzTwoTellar = true;
                    return localStats;
                }
                if (hand.Count(x => x.Level == 4 && x.Type == "Warrior" && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))) >= 1)
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}