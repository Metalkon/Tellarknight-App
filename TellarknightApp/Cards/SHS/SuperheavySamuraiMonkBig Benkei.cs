using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiMonkBigBenkei : Card
    {
        public SuperheavySamuraiMonkBigBenkei() 
        {
            Name = "Superheavy Samurai Monk Big Benkei";
            Type = "Machine";
            Attribute = "Earth";
            Level = 8;
            Attack = 1000;
            Defense = 3500;
            Scale = 1;
            Role = "Extender";
            Archetype = new List<string> { "SHS" };
            Id = 19510093;
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