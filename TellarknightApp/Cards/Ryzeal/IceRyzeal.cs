using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class IceRyzeal : Card
    {
        public IceRyzeal()
        {
            Name = "Ice Ryzeal";
            Type = "Pyro";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 1000;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Ryzeal" };
            Id = 08633261;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (deck.Any(x => x is not IceRyzeal && x.Archetype.Contains("Ryzeal") && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            if (hand.Any(x => x != this && x.Level == 4))
            {
                localStats.RyzealLock = true;
                return localStats;
            }

            return localStats;
        }
    }
}