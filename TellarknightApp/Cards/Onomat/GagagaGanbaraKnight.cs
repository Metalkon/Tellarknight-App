using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class GagagaGanbaraKnight : Card
    {
        public GagagaGanbaraKnight()
        {
            Name = "Gagaga Ganbara Knight";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat", "Gagaga" };
            Id = 09491461;
            Image = $"./CardArt/{Id:D8}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (extraDeck.Any(x => x.Archetype.Contains("Gagaga") && hand.Any(x => x != this && x.Level == 4)))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
                {
                    localStats.AverageXyzOneTellar = true;
                }
            }
            return localStats;
        }
    }
}