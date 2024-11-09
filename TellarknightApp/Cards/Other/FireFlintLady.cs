using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class FireFlintLady : Card
    {
        public FireFlintLady()
        {
            Name = "Fire Flint Lady";
            Type = "Warrior";
            Attribute = "Fire";
            Level = 1;
            Attack = 100;
            Defense = 100;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 42052439;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Two Warriors
            if (hand.Count(x => x.Level == 4 && x.Type == "Warrior") >= 2)
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