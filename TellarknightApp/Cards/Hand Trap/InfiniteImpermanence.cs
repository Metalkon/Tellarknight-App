using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class InfiniteImpermanence : Card
    {
        public InfiniteImpermanence()
        {
            Name = "Infinite Impermanence";
            Type = "Trap";
            Attribute = string.Empty;
            Level = 3;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 10045474;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}