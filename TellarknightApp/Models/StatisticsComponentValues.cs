using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class StatisticsComponentValues
    {
        public bool Active { get; set; }
        public int StartingHand { get; set; }
        public int MaximumCount { get; set; }
        public int CurrentCount { get; set; }
        public bool Idle { get; set; }
        public bool HandTested { get; set; }

        public StatisticsComponentValues() 
        {
            Active = false;
            StartingHand = 5;
            MaximumCount = 15000;
            CurrentCount = 0;
            Idle = true;
            HandTested = false;
        }
    }
}