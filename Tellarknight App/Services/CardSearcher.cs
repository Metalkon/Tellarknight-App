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
        public static (List<Card>, List<Card>, bool, List<Card>, List<Card>) CardSearch(List<Card> hand, List<Card> deck, bool normalSummon, List<Card> onField, List<Card> scales)
        {
            // If the hand/deck contains Zefraath, use Zefra Searches
            if (hand.Any(x => x.Name == "Zefraath") || deck.Any(x => x.Name == "Zefraath"))
            {
                // SHS Search/Setup
                (hand, deck, normalSummon, onField, scales) = ZefraRota(hand, deck, normalSummon, onField, scales);

            }

            // If the hand/deck does not contain Zefraath, use Standard Searches
            else if (!hand.Any(x => x.Name == "Zefraath") && !deck.Any(x => x.Name == "Zefraath"))
            {
                // SHS Search/Setup
                StandardRota(hand, deck);

            }
            // StandardRota(hand, deck);
            // SmallWorld(hand, deck);
            // NormalSummn(hand, deck);
            return (hand, deck, normalSummon, onField, scales);
        }

        // First string is the card used to search with, second string is the card that is being searched
        public static (List<Card>, List<Card>) UpdateCards(List<Card> hand, List<Card> deck, string searchCard, string searchTarget)
        {
            var card = deck.First(x => x.Name == searchTarget);
            deck.Remove(deck.First(x => x.Name == searchTarget));
            hand = hand.OrderByDescending(x => x.Name == searchCard).ToList();
            hand[0] = card;
            return (hand, deck);            
        }

        public static bool CheckUniqueCards(List<Card> hand, string minMax, int targetNumber, params string[] cards)
        {
            int count = 0;
            foreach (var card in cards)
            {
                if (hand.Any(x => x.Name == card))
                {
                    count++;
                    hand.RemoveAll(x => x.Name == card);
                }
            }
            if (minMax == "Min" && count >= targetNumber)
            {
                return true;
            }
            if (minMax == "Max" && count <= targetNumber)
            {
                return true;
            }
            return false;
        }

        public static (List<Card>, List<Card>, bool, List<Card>, List<Card>) ZefraRota(List<Card> hand, List<Card> deck, bool normalSummon, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Reinforcement of the Army";

            // ----- Zefra SHS -----

            // HAND: x1 Unique Oracle/Prov In Hand...  With SHS, No Zefraath -> Search Zefraath
            if (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefra Providence") == true
                && .Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi") 
                //&& (scales.Item1.Name == "Superheavy Samurai Monk Big Benkei" || scales.Item2.Name == "Superheavy Samurai Monk Big Benkei")
                && !hand.Any(x => x.Name == "Zefraath") && deck.Any(x => x.Name == "Zefraath"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x1 Zefraath In Hand...  With SHS, No Lyran -> Search Lyran
            if (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefra Providence") == true
                && deck.Any(x => x.Name == "Zefraath") && !hand.Any(x => x.Name == "Zefraath"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // ----- Zefra Normal -----

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand...  No Lyran -> Search Lyran
            if (CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban") == true
                && deck.Any(x => x.Name == "Tellarknight Lyran") && !hand.Any(x => x.Name == "Tellarknight Lyran")
                && !deck.Any(x => x.Name == "Tellarknight Lyran"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand...  No Lyran -> Search Lyran
            if (CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban") == true
                && deck.Any(x => x.Name == "Tellarknight Lyran") && !hand.Any(x => x.Name == "Tellarknight Lyran")
                && !deck.Any(x => x.Name == "Tellarknight Lyran"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand...  With Lyran -> Search Unuk
            if (CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban") == true
                && deck.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Tellarknight Lyran"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand... With Lyran+Unuk -> Search Deneb
            if (CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban") == true
                && deck.Any(x => x.Name == "Satellarknight Deneb") && hand.Any(x => x.Name == "Tellarknight Lyran") && hand.Any(x => x.Name == "Satellarknight Unukalhai"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand... With Lyran+Unuk+Deneb -> Search Thuban
            if (CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban") == true
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban") && hand.Any(x => x.Name == "Tellarknight Lyran") && hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }

            // HAND: x1 Unique Zefraath/Oracle/Prov/Thuban In Hand... With Deneb... -> Search Thuban
            if (CheckUniqueCards(hand, "Max", 1, "Zefraath", "Oracle of Zefra", "Zefra Providence") == true
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban") && hand.Any(x => x.Name == "Satellarknight Deneb") && hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                (hand, deck) = UpdateCards(hand, deck, searchCard, "Zefraath");
                return (hand, deck, normalSummon, onField, scales);
            }


            /*
            // HAND: x2 Unique Zefraath, Searcher Spells, or Zefrathuban In Hand... With Lyran
            if (!hand.Any(x => x.Name == "Zefraath") && (hand.Any(x => x.Name == "Oracle of Zefra") || hand.Any(x => x.Name == "Zefra Providence")))
            {
                //return (hand, deck) = UpdateCards(hand, deck, searchCard, "Tellarknight Lyran");

            }

            // HAND: x2 Unique Zefraath, Searcher Spells, or Zefrathuban In Hand... With Deneb
            if (!hand.Any(x => x.Name == "Zefraath") && (hand.Any(x => x.Name == "Oracle of Zefra") || hand.Any(x => x.Name == "Zefra Providence")))
            {
                //return (hand, deck) = UpdateCards(hand, deck, searchCard, "Tellarknight Lyran");

            }

            */
            return (hand, deck, normalSummon, onField, scales);

        }














        public static (List<Card>, List<Card>) StandardRota(List<Card> hand, List<Card> deck)
        {
            string searchCard = "Reinforcement of the Army";

            return (hand, deck);
        }
    }
}
