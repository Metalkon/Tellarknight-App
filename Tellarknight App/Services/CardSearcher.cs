using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellarknight_App.Models;

namespace Tellarknight_App.Services
{
    internal class CardSearcher
    {
        public static (List<Card>, List<Card>, bool, Card, (Card, Card)) CardSearch(List<Card> hand, List<Card> deck, bool normalSummon, Card onField, (Card, Card) scales)
        {
            Rota(hand, deck);
            hand.Add(new Card()
            {
                Name = "SEARCH TEST CARD"
            });
            // SmallWorld(hand, deck);
            // NormalSummn(hand, deck);
            return (hand, deck, normalSummon, onField, scales);
        }






        

        public static (List<Card>, List<Card>) Rota(List<Card> hand, List<Card> deck)
        {
            if (hand.Any(x => x.Name == "Oracle of Zefra") || hand.Any(x => x.Name == "Providence of Zefra"))
                {
                    var card = deck.First(x => x.Name == "Satellarknight Zefrathuban");
                    deck.Remove(deck.First(x => x.Name == "Satellarknight Zefrathuban"));
                    hand = hand.OrderByDescending(x => x.Name == "Reinforcement of the Army").ToList();
                    hand[0] = card;
                }
            


            return (hand, deck);
        }
    }
}
