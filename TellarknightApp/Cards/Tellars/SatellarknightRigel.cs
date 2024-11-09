using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightRigel : Card
    {
        public SatellarknightRigel() 
        {
            Name = "Satellarknight Rigel";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1900;
            Defense = 700;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 13851202;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}