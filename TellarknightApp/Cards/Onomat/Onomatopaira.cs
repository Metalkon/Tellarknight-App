using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Onomatopaira : Card
    {
        public Onomatopaira() 
        {
            Name = "Onomatopaira";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Onomat" };
            Id = 06595475;
            Image = $"./CardArt/{Id:D8}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            void BonusCard(string archetype, Type ?avoid)
            {
                Card searchedCard;
                if (avoid == null)
                    searchedCard = deck.FirstOrDefault(x => x.Archetype.Contains(archetype) && x.Level == 4);
                else
                    searchedCard = deck.FirstOrDefault(x => x.Archetype.Contains(archetype) && x.Level == 4 && x.GetType() != avoid);

                if (searchedCard != null)
                {
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                }
            }

            // Search D4 (Onomatokage)
            if ((hand.Any(x => x is Onomatokage) || deck.Any(x => x is Onomatokage))
                && deck.Any(x => x is DodododoWarrior))
            {
                Card searchedCard = deck.First(x => x is DodododoWarrior);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                BonusCard("Onomat", null);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search D4 (Glove)
            if (deck.Any(x => x is DodododwarfGogogoglove)
                && deck.Any(x => x is DodododoWarrior))
            {
                Card searchedCard = deck.First(x => x is DodododoWarrior);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                BonusCard("Onomat", typeof(DodododwarfGogogoglove));
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search D4 (Normal Summon)
            if (deck.Any(x => x.Archetype.Contains("Onomat") && x.Level == 4)
                && deck.Any(x => x is DodododoWarrior)
                && (deck.Count(x => x is DodododoWarrior) >= 2 || (deck.Any(x => x.Archetype.Contains("Dododo") && x.Level == 4) && deck.Count(x => x.Archetype.Contains("Onomat") && x.Level == 4) >= 2)))
            {
                Card searchedCard = deck.First(x => x is DodododoWarrior);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);

                if (deck.Count(x => x is DodododoWarrior) >= 2 || (hand.Any(x => x is DodododoWarrior) && deck.Any(x => x is DodododoWarrior)))
                {
                    BonusCard("Onomat", null);
                    return (hand, deck, extraDeck, gy, searched);
                }

                if (deck.Count(x => x.Archetype.Contains("Dododo") && x.Level == 4) <= 1 && deck.Count(x => x.Archetype.Contains("Onomat") && x.Level == 4) >= 2)
                {
                    BonusCard("Onomat", null);
                    return (hand, deck, extraDeck, gy, searched);
                }

                return (hand, deck, extraDeck, gy, searched);
            }

            // Ganbara
            if (extraDeck.Any(x => x.Archetype.Contains("Gagaga")) && deck.Any(x => x is GagagaGanbaraKnight) && (hand.Any(x => x.Level == 4) || deck.Count(x => x.Archetype.Contains("Onomat") && x.Level == 4) >= 2))
            {
                Card searchedCard = deck.First(x => x is GagagaGanbaraKnight);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                BonusCard("Onomat", null);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Onomatokage
            if (deck.Any(x => x is Onomatokage) && deck.Count(x => x.Archetype.Contains("Onomat") && x.Level == 4) >= 2)
            {
                Card searchedCard = deck.First(x => x is Onomatokage);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                BonusCard("Onomat", null);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Glove
            if (deck.Any(x => x is DodododwarfGogogoglove) && deck.Any(x => x.Archetype.Contains("Zubaba") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x is DodododwarfGogogoglove);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);

                searchedCard = deck.First(x => x.Archetype.Contains("Zubaba") && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);

                return (hand, deck, extraDeck, gy, searched);
            }

            // Coat
            if (deck.Any(x => x is ZubababanchoGagagacoat) && (hand.Any(x => x.Archetype.Contains("Gagaga") && x.Level == 4 && x is not ZubababanchoGagagacoat) || deck.Any(x => x.Archetype.Contains("Gagaga") && x.Level == 4 && x is not ZubababanchoGagagacoat)))
            {
                Card searchedCard = deck.First(x => x is ZubababanchoGagagacoat);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);

                if (deck.Any(x => x.Archetype.Contains("Gagaga") && x.Level == 4 && x is not ZubababanchoGagagacoat))
                    BonusCard("Onomat", null);

                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);

        }
    }
}