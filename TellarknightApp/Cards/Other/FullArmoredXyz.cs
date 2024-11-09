using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class FullArmoredXyz : Card
    {
        public FullArmoredXyz()
        {
            Name = "Full-Armored Xyz";
            Type = "Trap";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 39733924;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}