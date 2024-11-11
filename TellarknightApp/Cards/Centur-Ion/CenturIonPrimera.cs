using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonPrimera : Card
    {
        public CenturIonPrimera()
        {
            Name = "Centur-Ion Primera";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 15005145;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Stand Up
            if (deck.Any(x => x is StandUpCenturIon)
                && deck.Any(x => x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            // Bonds
            if (deck.Any(x => x is CenturIonBonds)
                && hand.Any(x => x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}