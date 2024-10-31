using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class DDCrow : Card
    {
        public DDCrow()
        {
            Name = "D.D. Crow";
            Type = "Winged Beast";
            Attribute = "Dark";
            Level = 1;
            Attack = 100;
            Defense = 100;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 24508238;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}