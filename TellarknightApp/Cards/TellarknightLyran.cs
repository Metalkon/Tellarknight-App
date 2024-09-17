using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class TellarknightLyran : Card
    {
        public TellarknightLyran() 
        {
            Name = "Tellarknight Lyran";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Image = "./CardArt/Lyran.png";
        }

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}