using TellarknightApp.Models;
using TellarknightApp.Services;

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
            Image = "./CardArt/Unuk.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            return localStats;
        }
    }
}