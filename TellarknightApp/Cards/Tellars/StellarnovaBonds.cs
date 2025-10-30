using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class StellarnovaBonds : Card
    {
        public StellarnovaBonds() 
        {
            Name = "Stellarnova Bonds";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Id = 99999999;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            bool superheavySamurai = false;
            bool superheavySamuraiFull = false;
            Card shsMonster = null;

            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                if (hand.Any(x => x is SuperheavySamuraiProdigyWakaushi))
                {
                    shsMonster = hand.First(x => x is SuperheavySamuraiProdigyWakaushi);
                }
                else
                {
                    shsMonster = hand.First(x => x is SuperheavySamuraiMotorbike);
                }
                if (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                {
                    superheavySamuraiFull = true;
                }
                else
                {
                    superheavySamurai = true;
                }
            }

            // Confirm Full Oracle Search (Don't Search If Not)
            if (superheavySamuraiFull == true
                && hand.Any(x => x is Zefraath || x is OracleOfZefra || x is ZefraProvidence)
                && (hand.Any(x => x is OracleOfZefra) || deck.Any(x => x is OracleOfZefra))
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))
            {
                hand.Add(new EmptyCard());
                return (hand, deck, extraDeck, gy, searched);
            }

            // Zefraath or Zefra Spell In Hand (Non-Oracle Combo, To Search Thuban)
            if ((hand.Any(x => x is Zefraath) || hand.Any(x => x is OracleOfZefra) || hand.Any(x => x is ZefraProvidence))
                && hand.Count(x => x is not SatellarknightZefrathuban) == 0 && deck.Any(x => x is SatellarknightZefrathuban) 
                && (deck.Any(x => x is ShaddollZefracore) || deck.Any(x => x is StellarknightZefraxciton)))
            {
                if (deck.Any(x => x is ConstellarCastor && deck.Any(x => x is TellarknightCygnian)))
                {
                    Card searchedCard = deck.First(x => x is ConstellarCastor);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
                if (deck.Any(x => x is TellarknightCygnian))
                {
                    Card searchedCard = deck.First(x => x is TellarknightCygnian);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
                if (deck.Any(x => x is SatellarknightDeneb))
                {
                    Card searchedCard = deck.First(x => x is SatellarknightDeneb);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
            }

            // Search Castor
            if (deck.Any(x => x is not ConstellarCastor && x.Level == 4 && x.Archetype.Contains("Constellar"))
                && deck.Any(x => x is ConstellarCastor))
            {
                Card searchedCard = deck.First(x => x is ConstellarCastor);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Cygnian
            if (deck.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) 
                && deck.Any(x => x is TellarknightCygnian) && deck.Count(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) >= 2)
            {
                Card searchedCard = deck.First(x => x is TellarknightCygnian);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Cygnian (Tellar CT Spell)
            if (hand.Any(x => x is TellarknightCygnian)
                && deck.Any(x => x is TellarknightCygnian)
                && deck.Any(x => x is not SatellarknightDeneb && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                Card searchedCard = deck.First(x => x is TellarknightCygnian);
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

            // Search Any Tellar
            if (deck.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4))
            {
                Card searchedCard = deck.First(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Search Other Tellar
            if (deck.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level != 4))
            {
                Card searchedCard = deck.First(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level != 4 && x.Level != null);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}