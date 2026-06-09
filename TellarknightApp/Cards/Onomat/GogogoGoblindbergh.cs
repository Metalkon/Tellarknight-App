using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class GogogoGoblindbergh : Card
    {
        public GogogoGoblindbergh()
        {
            Name = "Gogogo Goblindbergh";
            Type = "Warrior";
            Attribute = "Earth";
            Level = 4;
            Attack = 1400;
            Defense = 0;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat" };
            Id = 35886170;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}