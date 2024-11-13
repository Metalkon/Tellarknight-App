using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ThodeRyzeal : Card
    {
        public ThodeRyzeal()
        {
            Name = "Thode Ryzeal";
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

            if (deck.Any(x => x is IceRyzeal || x is ExRyzeal))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            return localStats;
        }
    }
}