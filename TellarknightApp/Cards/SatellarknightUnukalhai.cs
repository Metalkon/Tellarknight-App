using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightUnukalhai : Card
    {
        public SatellarknightUnukalhai() 
        {
            Name = "Satellarknight Unukalhai";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1800;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Unuk.png";
        }

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}