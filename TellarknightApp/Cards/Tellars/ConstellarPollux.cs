using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarPollux : Card
    {
        public ConstellarPollux()
        {
            Name = "Constellar Pollux";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 78364470;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x != this && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}