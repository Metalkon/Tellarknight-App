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
        public List<Card> CardResults { get; set; }

        public CardManager(SupportedCards supportedCards)
        {
            _supportedCards = supportedCards;

            MainDeck = new List<Card>();
            ExtraDeck = new List<Card>();
            SearchValues = new SearchValues();
            CardResults = _supportedCards.Cards.ToList();
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

        public async Task Search()
        {
            var filtered = _supportedCards.Cards
                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.SearchQuery) ||
                    x.Name.ToLower().Contains(SearchValues.SearchQuery.ToLower()))

                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.ArchetypeQuery) ||
                    (x.Archetype != null && x.Archetype.Contains(SearchValues.ArchetypeQuery)))

                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.TypeQuery) ||
                    (SearchValues.TypeQuery == "Monster"
                        ? (x.Type != "Spell" && x.Type != "Field Spell" && x.Type != "Trap")
                    : SearchValues.TypeQuery == "Spell (includes Field Spell)"
                        ? (x.Type == "Spell" || x.Type == "Field Spell")
                    : SearchValues.TypeQuery == "Extender"
                        ? x.Role == "Extender"
                    : SearchValues.TypeQuery == "Hand Trap"
                        ? x.Role == "Hand Trap"
                    : x.Type == SearchValues.TypeQuery))
                .ToList();

            SearchValues.TotalItems = filtered.Count;

            CardResults = filtered
                .Skip((SearchValues.CurrentPage - 1) * SearchValues.ItemsPerPage)
                .Take(SearchValues.ItemsPerPage)
                .ToList();
        }
    }
}

/*
            var filteredCards = CardManager.CardResults
            .Where(x => string.IsNullOrWhiteSpace(CardManager.SearchValues.SearchQuery.ToLower()) || x.Name.ToLower().Contains(CardManager.SearchValues.SearchQuery.ToLower()))
            .Where(x => string.IsNullOrWhiteSpace(CardManager.SearchValues.ArchetypeQuery) || x.Archetype.Contains(CardManager.SearchValues.ArchetypeQuery))
            .Where(x => string.IsNullOrWhiteSpace(CardManager.SearchValues.TypeQuery) ||
            (CardManager.SearchValues.TypeQuery == "Monster" ? (x.Type != "Spell" && x.Type != "Field Spell" && x.Type != "Trap") :
            (CardManager.SearchValues.TypeQuery == "Spell (includes Field Spell)" ? (x.Type == "Spell" || x.Type == "Field Spell") :
            (CardManager.SearchValues.TypeQuery == "Extender" ? x.Role == "Extender" :
            (CardManager.SearchValues.TypeQuery == "Hand Trap" ? x.Role == "Hand Trap" : x.Type == CardManager.SearchValues.TypeQuery)))))
            .ToList();


            CardManager.SearchValues.TotalItems = filteredCards.Count;
            var pagedCards = filteredCards
            .Skip((CardManager.SearchValues.CurrentPage - 1) * CardManager.SearchValues.ItemsPerPage)
            .Take(CardManager.SearchValues.ItemsPerPage);
*/