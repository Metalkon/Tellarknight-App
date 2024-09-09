using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    internal class SatellarknightDeneb : Card
    {
        SatellarknightDeneb() 
        {
            Name = "Satellarknight Deneb";
            Type = "Warrior";
            Level = 4;
            Scale = null;
            Archetype = "Tellarknight/Any";
            Image = "./CardArt/Deneb.png";
            Role = "Search";
        }

        public override GameState AnalyzeHand(GameState gameState)
        {
            CardHelper _cardHelper = new CardHelper();
            return gameState;
        }
    }
}
