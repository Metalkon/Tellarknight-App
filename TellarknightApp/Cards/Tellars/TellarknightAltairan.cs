using TellarknightApp.Models;

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
            Id = 42822433;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {


            return localStats;
        }
    }
}