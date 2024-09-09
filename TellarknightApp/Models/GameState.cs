using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Services;

namespace TellarknightApp.Models
{
    internal class GameState
    {
        public LocalStats LocalStats { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Gy { get; set; }
        public List<Card> OnField { get; set; }
        public List<Card> Scales { get; set; }
        public List<Card> ExtraDeck { get; set; }
        public bool NormalSummoned { get; set; }
    }
}
