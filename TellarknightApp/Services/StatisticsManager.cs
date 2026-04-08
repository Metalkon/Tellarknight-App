using System;
using System.Collections.Generic;
using System.Text;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class StatisticsManager
    {
        public StatValues Stats { get; set; }
        public DeckStatistics DeckStatistics { get; set; }
        public DeckStatistics DeckStatisticsHand { get; set; }

        public StatisticsManager()
        {
            Stats = new StatValues();
        }
    }
}
