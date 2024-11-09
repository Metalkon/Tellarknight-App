using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MajestyPegasusTheDracoslayer : Card
    {
        public MajestyPegasusTheDracoslayer()
        {
            Name = "Majesty Pegasus, the Dracoslayer";
            Type = "Spellcaster";
            Attribute = "Wind";
            Level = 4;
            Attack = 1500;
            Defense = 1500;
            Scale = 2;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 92332424;
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