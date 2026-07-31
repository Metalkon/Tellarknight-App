using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarCastor : Card
    {
        public ConstellarCastor()
        {
            Name = "Constellar Castor";
            Type = "Fairy";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 33302589;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Castor + Deck Summon
            if (deck.Any(x => x is not ConstellarCastor && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}