using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellarknight_App.Models;

namespace Tellarknight_App.Services
{
    internal class StandardAnalyzer
    {
        public static (List<Card>, List<Card>, bool, List<Card>, List<Card>, DeckStatistics) HandCheck(List<Card> hand, List<Card> deck, bool normalSummon, List<Card> onField, List<Card> scales, DeckStatistics stats)
        {
            return (hand, deck, normalSummon, onField, scales, stats);
        }

    }
}
