using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Cards;

namespace TellarknightApp.Models
{
    public class StatValues
    {
        public bool Active { get; set; }
        public int StartingHand { get; set; }
        public int MaximumCount { get; set; }
        public int CurrentCount { get; set; }
        public bool Idle { get; set; }
        public bool HandTested { get; set; }
        public List<Card> HandTest { get; set; }


        public StatValues() 
        {
            Active = false;
            StartingHand = 5;
            MaximumCount = 15000;
            CurrentCount = 0;
            Idle = true;
            HandTested = false;
            HandTest = new List<Card>()
        {
            new EmptyCard(){ Image = "./CardArt/CardBack.jpg" },
            new EmptyCard(){ Image = "./CardArt/CardBack.jpg" },
            new EmptyCard(){ Image = "./CardArt/CardBack.jpg" },
            new EmptyCard(){ Image = "./CardArt/CardBack.jpg" },
            new EmptyCard(){ Image = "./CardArt/CardBack.jpg" }
        };
        }
    }
}