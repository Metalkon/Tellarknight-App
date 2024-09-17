using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightVega : Card
    {
        public SatellarknightVega() 
        {
            Name = "Satellarknight Vega";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Vega.png";
        }

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}