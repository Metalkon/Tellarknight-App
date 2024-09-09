using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

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

        public override GameState AnalyzeHand(string name)
        {
            string result = $"Deneb: {name}";
            Console.WriteLine(result);
        }
    }
}
