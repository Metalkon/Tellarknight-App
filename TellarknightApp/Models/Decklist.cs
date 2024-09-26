using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class Decklist
    {
        public List<Card> MainDeck { get; set; }
        public List<Card> ExtraDeck { get; set; }

        public Decklist()
        {
            MainDeck = new List<Card>();
            ExtraDeck = new List<Card>();
        }
    }
}