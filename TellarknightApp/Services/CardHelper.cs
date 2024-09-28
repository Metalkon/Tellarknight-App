using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class CardHelper
    {
        public static bool CheckUniqueCards(List<Card> hand, string minMax, int targetNumber, params string[] cards)
        {
            List<Card> handCopy = hand.ToList();

            int count = 0;
            foreach (var card in cards)
            {
                if (handCopy.Any(x => x.Name == card))
                {
                    count++;
                    handCopy.RemoveAll(x => x.Name == card);
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
        public static (List<Card>, List<Card>) AddScale(List<Card> hand, List<Card> scales, string targetCard)
        {
            var cardHand = hand.First(x => x.Name == targetCard);

            hand.Remove(hand.First(x => x.Name == targetCard));
            scales.Add(cardHand);

            return (hand, scales);
        }

        public static (List<Card>, List<Card>) RemoveScale(List<Card> hand, List<Card> scales, string targetCard)
        {
            var cardHand = scales.First(x => x.Name == targetCard);

            scales.Remove(scales.First(x => x.Name == targetCard));
            hand.Add(cardHand);

            return (hand, scales);
        }

        public static bool CheckSHS(List<Card> onField, List<Card> scales)
        {
            if (onField.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi")
                && onField.Any(x => x.Name == "Superheavy Samurai Soulgaia Booster")
                && scales.Any(x => x.Name == "Superheavy Samurai Monk Big Benkei"))
            {
                return true;
            }
            return false;
        }

        public static int CountCards(List<Card> hand, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Name != exclude);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Name != exclude1 && x.Name != exclude2);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level && x.Name != exclude));

            return matchingCards.Count();
        }
        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level && x.Name != exclude1 && x.Name != exclude2));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && x.Name != exclude);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && x.Name != exclude1 && x.Name != exclude2);

            return matchingCards.Count();
        }

        /*
        public static int CountCards(List<Card> hand, string archetype1, int level, params string[] exclusions)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Archetype.Contains(archetype1) && !exclusions.Contains(x.Name));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string archetype1, string archetype2, int level, params string[] exclusions)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && !exclusions.Contains(x.Name));

            return matchingCards.Count();
        }
         */
    }
}
