using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class PalmaRyzeal : Card
    {
        public PalmaRyzeal()
        {
            Name = "Palma Ryzeal";
            Type = "Thunder";
            Attribute = "Fire";
            Level = 4;
            Attack = 1200;
            Defense = 2400;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Ryzeal" };
            Id = 61116514;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Count(x => x.Archetype.Contains("Ryzeal") && x.Level == 4) >= 3
                || (hand.Count(x => x.Archetype.Contains("Ryzeal") && x.Level == 4) >= 2 && hand.Count(x => x.Level == 4) >= 3))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            return localStats;
        }
    }
}