using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightSirius : Card
    {
        public SatellarknightSirius() 
        {
            Name = "Satellarknight Sirius";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 63274863;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}