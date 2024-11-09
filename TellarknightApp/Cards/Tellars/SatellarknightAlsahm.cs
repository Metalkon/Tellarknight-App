using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightAlsahm : Card
    {
        public SatellarknightAlsahm() 
        {
            Name = "Satellarknight Alsahm";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1400;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 65056481;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}