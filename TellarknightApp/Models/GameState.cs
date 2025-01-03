﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class GameState
    {
        public LocalStats LocalStats { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Gy { get; set; }
        public List<Card> ExtraDeck { get; set; }

        public GameState()
        {
            LocalStats = new LocalStats();
            Hand = new List<Card>();
            Deck = new List<Card>();
            Gy = new List<Card>();
            ExtraDeck = new List<Card>();
        }
    }


}
