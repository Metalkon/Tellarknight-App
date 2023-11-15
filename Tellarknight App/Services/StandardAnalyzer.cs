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
        public static (List<Card>, List<Card>, bool, Card, DeckStatistics, (Card, Card)) HandCheck(List<Card> hand, List<Card> deck, bool normalSummon, Card onField, DeckStatistics stats, (Card, Card) scales)
        {
            return (hand, deck, normalSummon, onField, stats, scales);
        }

    }
}
