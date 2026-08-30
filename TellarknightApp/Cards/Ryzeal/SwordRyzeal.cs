using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SwordRyzeal : Card
    {
        public SwordRyzeal()
        {
            Name = "Sword Ryzeal";
            Type = "Thunder";
            Attribute = "Fire";
            Level = 4;
            Attack = 1500;
            Defense = 200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Ryzeal" };
            Id = 35844557;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x != this && x.Archetype.Contains("Ryzeal") && x.Level == 4))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            if (deck.Any(x => x is IceRyzeal || x is ExtRyzeal))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            return localStats;
        }
    }
}