using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ReinforcementOfTheArmy : Card
    {
        public ReinforcementOfTheArmy() 
        {
            Name = "Reinforcement of the Army";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 32807846;
            Image = $"./CardArt/{Id}.jpg";

        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Search Cygnian
            if (deck.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))
                && deck.Any(x => x is TellarknightCygnian) && deck.Count(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) >= 2)
            {
                Card searchedCard = deck.First(x => x is TellarknightCygnian);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Lyran (Normal)
            if (hand.Any(x => x is not TellarknightLyran && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4)
                && deck.Any(x => x is TellarknightLyran))
            {
                Card searchedCard = deck.First(x => x is TellarknightLyran);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Vega (Normal)
            if (hand.Any(x => x is not SatellarknightVega && x.Archetype.Contains("Tellarknight") && x.Level == 4)
                && deck.Any(x => x is SatellarknightVega))
            {
                Card searchedCard = deck.First(x => x is SatellarknightVega);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Any Tellar (Normal)
            if (hand.Any(x => x is TellarknightLyran)
                && deck.Any(x => x is not TellarknightLyran && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4 && x.Type == "Warrior"))
            {
                Card searchedCard = deck.First(x => x is not TellarknightLyran && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4 && x.Type == "Warrior");
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Deneb (Tellar CT Spell)
            if (hand.Any(x => x is ConstellarTellarknights) 
                && deck.Any(x => x is SatellarknightDeneb) 
                && deck.Any(x => x is not SatellarknightDeneb && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x is SatellarknightDeneb);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Unuk (Tellar CT Spell)
            if (hand.Any(x => x is ConstellarTellarknights)
                && deck.Any(x => x is SatellarknightUnukalhai)
                && deck.Any(x => x is not SatellarknightUnukalhai && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x is SatellarknightUnukalhai);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Pollux
            if (hand.Any(x => x.Archetype.Contains("Constellar") && x.Level == 4 )
                && deck.Any(x => x is ConstellarPollux))
            {
                Card searchedCard = deck.First(x => x is ConstellarPollux);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Warrior Extender
            if (deck.Any(x => x.Type == "Warrior" && x.Role == "Extender" && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x.Type == "Warrior" && x.Role == "Extender" && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Any Warrior
            if (deck.Any(x => x.Type == "Warrior" && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x.Type == "Warrior" && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}