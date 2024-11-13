using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class BlackwingZephyrostheElite : Card
    {
        public BlackwingZephyrostheElite()
        {
            Name = "Blackwing - Zephyros the Elite";
            Type = "Dark";
            Attribute = "Winged Beast";
            Level = 4;
            Attack = 1600;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 14785765;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}