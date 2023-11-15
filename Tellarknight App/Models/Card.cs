using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellarknight_App.Models
{
    internal class Card
    {
        public string Name { get; set; }
        public string? Type { get; set; }
        public int? Level { get; set; }
        public string? Archetype { get; set; }
        public string? Role { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
    }
}
