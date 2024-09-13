using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightDeneb : Card
    {
        public SatellarknightDeneb() 
        {
            Name = "Satellarknight Deneb";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1500;
            Defense = 1000;
            Scale = null;
            Role = null;
            Archetype = "Tellarknight";
            Image = "./CardArt/Deneb.png";
        }

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}