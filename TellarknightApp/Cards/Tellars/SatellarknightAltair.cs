using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightAltair : Card
    {
        public SatellarknightAltair() 
        {
            Name = "Satellarknight Altair";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 1300;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Altair.png";
            Id = 02273734;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}