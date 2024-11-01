using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ZoodiacRatpier : Card
    {
        public ZoodiacRatpier()
        {
            Name = "Zoodiac Ratpier";
            Type = "Beast-Warrior";
            Attribute = "Earth";
            Level = 4;
            Attack = 0;
            Defense = 0;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Zoodiac" };
            Id = 78872731;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}