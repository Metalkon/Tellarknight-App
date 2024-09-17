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

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}