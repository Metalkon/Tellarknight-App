using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CrossoutDesignator : Card
    {
        public CrossoutDesignator() 
        {
            Name = "Crossout Designator";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 65681983;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}