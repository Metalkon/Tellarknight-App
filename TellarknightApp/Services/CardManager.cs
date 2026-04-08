using TellarknightApp.Cards;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class CardManager
    {
        private readonly SupportedCards _supportedCards;

        public List<Card> MainDeck { get; set; }
        public List<Card> ExtraDeck { get; set; }
        public SearchValues SearchValues { get; set; }

        public CardManager(SupportedCards supportedCards)
        {
            _supportedCards = supportedCards;

            MainDeck = new List<Card>();
            ExtraDeck = new List<Card>();
            SearchValues = new SearchValues();
        }

        // Clears the statistics
        public void RefreshCards()
        {
            SearchValues = new SearchValues();
            BuildDecklist();
        }

        public void BuildDecklist()
        {
            MainDeck.Clear();
            ExtraDeck.Clear();

            foreach (Card card in _supportedCards.Cards)
            {
                if (card.Quantity > 3 && card is not Level4 && card is not EmptyCard)
                {
                    card.Quantity = 3;
                }
                if (card.Quantity > 0 && card.Role != "Extra Deck")
                {
                    for (int i = 0; i < card.Quantity; i++)
                    {
                        MainDeck.Add(card);
                    }
                }
                if (card.Quantity > 0 && card.Role == "Extra Deck")
                {
                    for (int i = 0; i < card.Quantity; i++)
                    {
                        ExtraDeck.Add(card);
                    }
                }
            }
            while (MainDeck.Count < 40)
            {
                MainDeck.Add(new EmptyCard());
            }
            //Action?.Invoke();
        }
    }
}
