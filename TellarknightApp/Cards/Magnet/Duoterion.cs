using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Duoterion : Card
    {
        public Duoterion()
        {
            Name = "Duoterion";
            Type = "Dinosaur";
            Attribute = "Water";
            Level = 5;
            Attack = 2000;
            Defense = 1400;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Magnet" };
            Id = 43017476;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Bonding
            if (deck.Any(x => x is MagnetBonding))
            {
                Card searchedCard = deck.First(x => x is MagnetBonding);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}