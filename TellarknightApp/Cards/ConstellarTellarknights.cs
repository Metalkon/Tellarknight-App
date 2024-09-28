using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarTellarknights : Card
    {
        public ConstellarTellarknights() 
        {
            Name = "Constellar Tellarknights";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Image = "./CardArt/ConstellarTellarknights.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}