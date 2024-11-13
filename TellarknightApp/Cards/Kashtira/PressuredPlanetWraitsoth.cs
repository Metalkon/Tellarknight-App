using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class PressuredPlanetWraitsoth : Card
    {
        public PressuredPlanetWraitsoth()
        {
            Name = "Pressured Planet Wraitsoth";
            Type = "Field Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Kashtira" };
            Id = 71832012;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Search Riseheart #1
            if (hand.Any(x => x is KashtiraRiseheart)
                && deck.Any(x => x is KashtiraRiseheart))
            {
                Card searchedCard = deck.First(x => x is KashtiraRiseheart);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Unicorn 1CC
            if (deck.Any(x => x is KashtiraUnicorn)
                && (hand.Any(x => x is Kashtiratheosis) || deck.Any(x => x is Kashtiratheosis))
                && deck.Any(x => x is KashtiraFenrir)
                && (hand.Any(x => x is KashtiraRiseheart) || deck.Any(x => x is KashtiraRiseheart))
                && extraDeck.Any(x => x is RaidraptorArsenalFalcon)
                && (hand.Any(x => x is BlackwingZephyrostheElite) || deck.Any(x => x is BlackwingZephyrostheElite)))
            {
                Card searchedCard = deck.First(x => x is KashtiraUnicorn);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Fenrir
            if (deck.Any(x => x is KashtiraFenrir)
                && deck.Any(x => x is KashtiraRiseheart))
            {
                Card searchedCard = deck.First(x => x is KashtiraFenrir);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Riseheart #2
            if (hand.Any(x => x.Archetype.Contains("Kashtira") && x.Level != null)
                && deck.Any(x => x is KashtiraRiseheart))
            {
                Card searchedCard = deck.First(x => x is KashtiraRiseheart);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}