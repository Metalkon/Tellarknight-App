using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarCaduceus : Card
    {
        public ConstellarCaduceus() 
        {
            Name = "Constellar Caduceus";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 1550;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Image = "./CardArt/Caduceus.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}