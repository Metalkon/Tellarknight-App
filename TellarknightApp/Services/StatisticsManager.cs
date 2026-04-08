using System;
using System.Collections.Generic;
using System.Text;
using TellarknightApp.Components.Pages;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class StatisticsManager
    {
        public StatValues StatValues { get; set; }
        public DeckStatistics DeckStatistics { get; set; }
        public DeckStatistics DeckStatisticsHand { get; set; }

        public StatisticsManager()
        {
            StatValues = new StatValues();
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
        }

        // Clears the statistics
        public void RefreshStatistics()
        {
            StatValues = new StatValues();
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
        }
    }
}
