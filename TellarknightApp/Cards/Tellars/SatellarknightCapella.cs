using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightCapella : Card
    {
        public SatellarknightCapella() 
        {
            Name = "Satellarknight Capellam";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1100;
            Defense = 2000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 86466163;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}