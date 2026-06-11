using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Duoterion : Card
    {
        public Duoterion()
        {
            Name = "Duoterion";
            Type = "Dinosaur";
            Attribute = "Water";
            Level = 5;
            Attack = 2000;
            Defense = 1400;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Magnet" };
            Id = 43017476;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}