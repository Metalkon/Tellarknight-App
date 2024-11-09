using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ZefraniuSecretOfTheYangZing : Card
    {
        public ZefraniuSecretOfTheYangZing() 
        {
            Name = "Zefraniu, Secret of the Yang Zing";
            Type = "Wyrm";
            Attribute = "Earth";
            Level = 6;
            Attack = 0;
            Defense = 2600;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "Yang Zing", "Zefra" };
            Id = 58990362;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales
            if (hand.Any(x => x.Scale <= 3))
            {
                highScale = this;

                if (hand.Any(x => x.Scale <= 3 && x.Level != 4))
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else if (hand.Any(x => x.Scale  <= 3 && x.Level == 4 && x is not SatellarknightZefrathuban))
                    lowScale = hand.First(x => x.Scale  <= 3 && x.Level == 4 && x is not SatellarknightZefrathuban);
                else if (hand.Any(x => x is SatellarknightZefrathuban))
                    lowScale = hand.First(x => x is SatellarknightZefrathuban);
            }

            // Zefra Pend
            if (lowScale != null && highScale != null)
            {
                if (hand.Count(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x != lowScale && x != highScale) >= 1
                    && hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}