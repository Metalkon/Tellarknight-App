using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Cards;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class GameState
    {
        public LocalStats LocalStats { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Gy { get; set; }
        public List<Card> ExtraDeck { get; set; }

        public GameState()
        {
            LocalStats = new LocalStats();
            Hand = new List<Card>();
            Deck = new List<Card>();
            Gy = new List<Card>();
            ExtraDeck = new List<Card>();
        }

        // Clears the gamestate and transfer cardmanager deck contents to gamestate
        public void RefreshGameState(List<Card> mainDeck, List<Card> extraDeck)
        {
            LocalStats = new LocalStats();
            Hand.Clear();
            Gy.Clear();
            Deck.Clear();
            ExtraDeck.Clear();

            foreach (Card card in mainDeck)
                Deck.Add(card.Clone());

            foreach (Card card in extraDeck)
                ExtraDeck.Add(card.Clone());
        }

        public void DrawHand(int startingHand)
        {
            for (int i = 0; i < startingHand; i++)
            {
                Hand.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
        }
        public void ShuffleDeck()
        {
            var random = new Random();
            int deckCount = Deck.Count;
            for (int i = 0; i < 3; i++)
            {
                while (deckCount > 1)
                {
                    deckCount--;
                    int randomIndex = random.Next(deckCount + 1);
                    var tempCard = Deck[randomIndex];
                    Deck[randomIndex] = Deck[deckCount];
                    Deck[deckCount] = tempCard;
                }
            }
        }



    }
}
