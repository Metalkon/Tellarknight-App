using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightProcyon : Card
    {
        public SatellarknightProcyon() 
        {
            Name = "Satellarknight Procyon";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1300;
            Defense = 1200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 99668578;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}