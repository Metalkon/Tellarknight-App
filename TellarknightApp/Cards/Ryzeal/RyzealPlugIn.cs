using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RyzealPlugIn : Card
    {
        public RyzealPlugIn() 
        {
            Name = "Ryzeal Plug-In";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Ryzeal" };
            Id = 60394026;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}