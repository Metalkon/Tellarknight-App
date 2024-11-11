using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class EmblemaOath : Card
    {
        public EmblemaOath()
        {
            Name = "Emblema Oath";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Searcher = true;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 77765207;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Search Stand Up
            if (hand.Count(x => x is StandUpCenturIon) == 0
                && deck.Any(x => x is StandUpCenturIon))
            {
                Card searchedCard = deck.First(x => x is StandUpCenturIon);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Bonds
            if (hand.Count(x => x is CenturIonBonds) == 0
                && deck.Any(x => x is CenturIonBonds))
            {
                Card searchedCard = deck.First(x => x is CenturIonBonds);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}