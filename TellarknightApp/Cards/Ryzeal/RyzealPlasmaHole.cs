using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RyzealPlasmaHole : Card
    {
        public RyzealPlasmaHole() 
        {
            Name = "Ryzeal Plasma Hole-----**";
            Type = "Trap";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Ryzeal" };
            Id = 33787730;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}