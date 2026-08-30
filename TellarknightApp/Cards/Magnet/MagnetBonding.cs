using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MagnetBonding : Card
    {
        public MagnetBonding() 
        {
            Name = "Magnet Bonding";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Magnet" };
            Id = 65514302;
            Image = $"./CardArt/{Id:D8}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            int totalCount = hand.Count(x => x.Archetype.Contains("Magnet") && x.Level == 4) + deck.Count(x => x.Archetype.Contains("Magnet") && x.Level == 4);

            if (totalCount >= 2)
            {
                // Conduction
                if (deck.Any(x => x is ConductionWarriorLinearMagnumPlusMinus))
                {
                    Card searchedCard = deck.First(x => x is ConductionWarriorLinearMagnumPlusMinus);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
            }
            else
            {
                // OmegaPlus
                if (deck.Any(x => x is MagnetWarriorOmegaPlus))
                {
                    Card searchedCard = deck.First(x => x is MagnetWarriorOmegaPlus);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // SigmaPlus
                if (deck.Any(x => x is MagnetWarriorSigmaPlus))
                {
                    Card searchedCard = deck.First(x => x is MagnetWarriorSigmaPlus);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Epsilon
                if (deck.Any(x => x is EpsilonTheMagnetWarrior))
                {
                    Card searchedCard = deck.First(x => x is EpsilonTheMagnetWarrior);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // SigmaMinus
                if (deck.Any(x => x is MagnetWarriorSigmaMinus))
                {
                    Card searchedCard = deck.First(x => x is MagnetWarriorSigmaMinus);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Any Magnet
                if (deck.Any(x => x.Archetype.Contains("Magnet") && x.Level == 4))
                {
                    Card searchedCard = deck.First(x => x.Archetype.Contains("Magnet") && x.Level == 4);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}