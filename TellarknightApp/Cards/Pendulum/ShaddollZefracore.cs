using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ShaddollZefracore : Card
    {
        public ShaddollZefracore() 
        {
            Name = "Shaddoll Zefracore";
            Type = "Rock";
            Attribute = "Dark";
            Level = 4;
            Attack = 450;
            Defense = 1950;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "Shaddoll", "Zefra" };
            Id = 95401059;
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