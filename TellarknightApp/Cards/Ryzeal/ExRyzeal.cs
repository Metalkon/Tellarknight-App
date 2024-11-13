using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ExRyzeal : Card
    {
        public ExRyzeal()
        {
            Name = "Ex Ryzeal";
            Type = "Thunder";
            Attribute = "Fire";
            Level = 4;
            Attack = 500;
            Defense = 2000;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Ryzeal" };
            Id = 34022970;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x != this && x.Level == 4))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            if (deck.Any(x => x is ThodeRyzeal))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            return localStats;
        }
    }
}