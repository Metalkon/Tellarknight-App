using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Bonfire : Card
    {
        public Bonfire() 
        {
            Name = "Bonfire";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 85106525;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Search Ice Ryzeal (1CC)
            if (deck.Any(x => x is IceRyzeal) 
                && deck.Any(x => x is not IceRyzeal && x.Archetype.Contains("Ryzeal") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x is IceRyzeal);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Centur-Ion Trudea (1CC)
            if (deck.Any(x => x is CenturIonTrudea)
                && (hand.Any(x => x is CenturIonPrimera) || deck.Any(x => x is CenturIonPrimera))
                && (hand.Any(x => x is StandUpCenturIon) || deck.Any(x => x is StandUpCenturIon))
                && deck.Any(x => x is not CenturIonTrudea && x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
            {
                Card searchedCard = deck.First(x => x is CenturIonTrudea);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Ex Ryzeal
            if (deck.Any(x => x is ExRyzeal))
            {
                Card searchedCard = deck.First(x => x is ExRyzeal);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Any Lv4 Pyro
            if (deck.Any(x => x.Type == "Pyro" && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x.Type == "Pyro" && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}