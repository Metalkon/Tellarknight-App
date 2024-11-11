using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonTrudea : Card
    {
        public CenturIonTrudea()
        {
            Name = "Centur-Ion Trudea";
            Type = "Pyro";
            Attribute = "Dark";
            Level = 4;
            Attack = 1000;
            Defense = 2000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 42493140;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Stand Up
            if ((hand.Any(x => x is CenturIonPrimera) || deck.Any(x => x is CenturIonPrimera))
                && deck.Any(x => x is StandUpCenturIon)
                && deck.Any(x => x is not CenturIonTrudea && x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            // Bonds
            if ((hand.Any(x => x is CenturIonPrimera) || deck.Any(x => x is CenturIonPrimera))
                && deck.Any(x => x is CenturIonBonds)
                && hand.Any(x => x is not CenturIonTrudea && x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}