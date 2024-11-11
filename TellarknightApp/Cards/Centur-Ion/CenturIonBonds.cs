using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonBonds : Card
    {
        public CenturIonBonds()
        {
            Name = "Centur-Ion Bonds";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 04160316;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Extend Centur-Ion In Hand + Lv4
            if ((hand.Count(x => x.Level == 4) >= 2 || (hand.Any(x => x.Level == 4) && hand.Any(x => x is CenturIonGargoyleII)))
                && hand.Any(x => x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            return localStats;
        }
    }
}