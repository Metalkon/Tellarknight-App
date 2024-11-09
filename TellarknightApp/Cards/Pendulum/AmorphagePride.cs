using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class AmorphagePride : Card
    {
        public AmorphagePride()
        {
            Name = "Amorphage Pride";
            Type = "Dragon";
            Attribute = "Earth";
            Level = 4;
            Attack = 1750;
            Defense = 0;
            Scale = 3;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 06283472;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales
            if (hand.Any(x => x.Scale <= 5))
            {
                lowScale = this;

                if (hand.Any(x => x.Scale  >= 5 && x.Level != 4))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                else if (hand.Any(x => x.Scale  >= 5 && x.Level == 4 && x.Archetype.Contains("Zefra") == false))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level == 4);
            }

            // Pend
            if (lowScale != null && highScale != null)
            {
                if (hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}