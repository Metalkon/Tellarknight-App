using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarSheratan : Card
    {
        public ConstellarSheratan() 
        {
            Name = "Constellar Sheratan";
            Type = "Beast";
            Attribute = "Light";
            Level = 3;
            Attack = 700;
            Defense = 1900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Image = "./CardArt/Sheratan.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}