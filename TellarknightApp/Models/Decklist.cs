using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class Decklist
    {
        public List<Card> Cards { get; set; }

        public Decklist()
        {
            Cards = new List<Card>();
        }
    }
}