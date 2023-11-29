using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    internal class StandardAnalyzer
    {
        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>, DeckStatistics) HandCheck(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummon, List<Card> onField, List<Card> scales, DeckStatistics stats)
        {
            return (hand, deck, gy, normalSummon, onField, scales, stats);
        }

    }
}
