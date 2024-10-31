using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class DrollLockBird : Card
    {
        public DrollLockBird()
        {
            Name = "Droll & Lock Bird";
            Type = "Spellcaster";
            Attribute = "Wind";
            Level = 1;
            Attack = 0;
            Defense = 0;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 94145021;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}