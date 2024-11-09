using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CynetMining : Card
    {
        public CynetMining() 
        {
            Name = "Cynet Mining";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 57160136;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Circular
            if (hand.Any(x => x is MathmechCircular) == false && deck.Any(x => x is MathmechCircular))
            {
                Card searchedCard = deck.First(x => x is MathmechCircular);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Other Mathmech
            if (deck.Any(x => x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x.Archetype.Contains("Mathmech") && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Other Cyberse
            if (deck.Any(x => x.Type == "Cyberse" && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x.Type == "Cyberse" && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                searched = true;
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}