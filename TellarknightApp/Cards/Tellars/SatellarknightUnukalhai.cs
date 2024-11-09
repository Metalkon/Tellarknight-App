using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightUnukalhai : Card
    {
        public SatellarknightUnukalhai() 
        {
            Name = "Satellarknight Unukalhai";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1800;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 01050186;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}