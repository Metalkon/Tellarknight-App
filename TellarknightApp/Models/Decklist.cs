using TellarknightApp.Cards;

namespace TellarknightApp.Models
{
    public class Decklist
    {
        public event Action? Action;
        public List<Card> MainDeck { get; set; }
        public List<Card> ExtraDeck { get; set; }

        public Decklist()
        {
            MainDeck = new List<Card>();
            ExtraDeck = new List<Card>();
        }

        public void BuildDecklist(SupportedCards supportedCards)
        {
            MainDeck.Clear();
            ExtraDeck.Clear();

            foreach (Card card in supportedCards.Cards)
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
            Action?.Invoke();
        }
    }
}