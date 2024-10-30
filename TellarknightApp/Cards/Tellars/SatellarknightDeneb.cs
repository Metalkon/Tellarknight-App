using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightDeneb : Card
    {
        public SatellarknightDeneb() 
        {
            Name = "Satellarknight Deneb";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1500;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 75878039;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Add Pend Search
            // 

            return localStats;
        }
    }
}