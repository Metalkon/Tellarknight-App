using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SeventhAscension : Card
    {
        public SeventhAscension() 
        {
            Name = "Seventh Ascension";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 23153227;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Search Seventh Tachyon
            if (hand.Count(x => x is SeventhTachyon) == 0
                && deck.Any(x => x is SeventhTachyon))
            {
                Card searchedCard = deck.First(x => x is SeventhTachyon);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}