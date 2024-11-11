using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class StandUpCenturIon : Card
    {
        public StandUpCenturIon()
        {
            Name = "Stand Up Centur-Ion!";
            Type = "Field Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Searcher = true;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 41371602;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Primera Search Lv4
            if(deck.Any(x => x is CenturIonPrimera)
                && deck.Any(x => x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            // Primera Search Bonds
            if (deck.Any(x => x is CenturIonPrimera)
                && hand.Any(x => x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII))
                && deck.Any(x => x is CenturIonBonds))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            // Trudea -> Primera -> Bonds
            if (deck.Any(x => x is CenturIonTrudea)
                && (hand.Any(x => x is CenturIonPrimera) || deck.Any(x => x is CenturIonPrimera))
                && deck.Any(x => x is CenturIonBonds)
                && deck.Any(x => x is not CenturIonPrimera && x is not CenturIonTrudea && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            // Extender + Lv4
            if (hand.Any(x => x.Level == 4)
                && deck.Any(x => x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
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