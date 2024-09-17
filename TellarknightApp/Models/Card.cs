using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public int? Level { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? Scale { get; set; }
        public List<string>? Archetype { get; set; }
        public string? Role { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public Card()
        {
            Name = string.Empty;
            Type = string.Empty;
            Attribute = string.Empty;
            Archetype = new List<string> { "None" };
            Role = string.Empty;
            Image = "./CardArt/CardBack.png";
            Quantity = 0;
        }

        public virtual GameState AnalyzeHand(GameState gameState)
        {
            return gameState;
        }
    }
}
