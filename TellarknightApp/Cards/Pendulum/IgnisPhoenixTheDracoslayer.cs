using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class IgnisPhoenixTheDracoslayer : Card
    {
        public IgnisPhoenixTheDracoslayer()
        {
            Name = "Ignis Phoenix, the Dracoslayer";
            Type = "Warrior";
            Attribute = "Fire";
            Level = 4;
            Attack = 1700;
            Defense = 1900;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 56347375;
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
                    highScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else if (hand.Any(x => x.Scale <= 3 && x.Level == 4 && x.Archetype.Contains("Zefra") == false))
                    highScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
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