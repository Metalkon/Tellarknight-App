using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TherionKingRegulus : Card
    {
        public TherionKingRegulus()
        {
            Name = "Therion \"King\" Regulusa";
            Type = "Machine";
            Attribute = "Earth";
            Level = 8;
            Attack = 2800;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 10604644;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}