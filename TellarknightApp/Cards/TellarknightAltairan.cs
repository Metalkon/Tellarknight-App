using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class TellarknightAltairan : Card
    {
        public TellarknightAltairan() 
        {
            Name = "Tellarknight Altairan";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 1300;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Image = "./CardArt/Altairan.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}