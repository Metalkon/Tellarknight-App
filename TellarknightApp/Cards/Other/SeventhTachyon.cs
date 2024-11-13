using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SeventhTachyon : Card
    {
        public SeventhTachyon() 
        {
            Name = "Seventh Tachyon";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 07477101;
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

            // Confirm Oracle Search (Don't Search If Not)
            if (superheavySamurai == true
                && hand.Any(x => x is Zefraath || x is OracleOfZefra || x is ZefraProvidence)
                && (hand.Any(x => x is OracleOfZefra) || deck.Any(x => x is OracleOfZefra))
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4))
                && hand.Any(x => x.Level == 4 && x != shsMonster))
            {
                hand.Add(new EmptyCard());
                return (hand, deck, extraDeck, gy, searched);
            }

            // Check Xyz Condition
            if (extraDeck.Any(x => x is Number104Masquerade))
            {
                // Zefraath or Zefra Spell In Hand
                if (superheavySamurai == false
                    && (hand.Any(x => x is Zefraath) || hand.Any(x => x is OracleOfZefra) || hand.Any(x => x is ZefraProvidence))
                    && hand.Count(x => x is not SatellarknightZefrathuban) == 0 && deck.Any(x => x is SatellarknightZefrathuban))
                {
                    Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Search Lyran (Zefraath)
                if ((hand.Any(x => x is Zefraath) || hand.Any(x => x is OracleOfZefra) || hand.Any(x => x is ZefraProvidence))
                    && hand.Any(x => x is SatellarknightZefrathuban)
                    && hand.Count(x => x is not TellarknightLyran) == 0 && deck.Any(x => x is TellarknightLyran))
                {
                    Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
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
                if (hand.Any(x => x.Archetype.Contains("Constellar") && x.Level == 4)
                    && deck.Any(x => x is ConstellarPollux))
                {
                    Card searchedCard = deck.First(x => x is ConstellarPollux);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Search Centur-Ion Primera
                if (deck.Any(x => x is CenturIonPrimera)
                    && deck.Any(x => x is StandUpCenturIon)
                    && deck.Any(x => x is not CenturIonPrimera && x.Archetype.Contains("Centur-Ion") && (x.Level == 4 || x is CenturIonGargoyleII)))
                {
                    Card searchedCard = deck.First(x => x is CenturIonPrimera);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Search Light Extender
                if (deck.Any(x => x.Attribute == "Light" && x.Role == "Extender" && x.Level == 4))
                {
                    Card searchedCard = deck.First(x => x.Attribute == "Light" && x.Role == "Extender" && x.Level == 4);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }

                // Search Light Level 4
                if (deck.Any(x => x.Attribute == "Light" && x.Level == 4))
                {
                    Card searchedCard = deck.First(x => x.Attribute == "Light" && x.Level == 4);
                    hand.Add(searchedCard);
                    deck.Remove(searchedCard);
                    return (hand, deck, extraDeck, gy, searched);
                }
            }
            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}