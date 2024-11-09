using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class InfernobleKnightRenaud : Card
    {
        public InfernobleKnightRenaud()
        {
            Name = "Infernoble Knight - Renaud";
            Type = "Warrior";
            Attribute = "Fire";
            Level = 1;
            Attack = 500;
            Defense = 200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 56824871;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}