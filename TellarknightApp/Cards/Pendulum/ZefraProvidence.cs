using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ZefraProvidence : Card
    {
        public ZefraProvidence() 
        {
            Name = "Zefra Providence";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Zefra" };
            Id = 74580251;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> gy, bool searched)
        {
            bool superheavySamurai = false;

            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                superheavySamurai = true;
            }

            // Search Oracle of Zefra (Optimal Oracle Combo)
            if (superheavySamurai == true
                && hand.Count(x => x is OracleOfZefra) == 0
                && hand.Any(x => x is Zefraath)
                && hand.Count(x => x.Archetype.Contains("Zefra") && x.Level == 4) == 0
                && deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)
                && deck.Any(x => x is OracleOfZefra)
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                )
            {
                Card searchedCard = deck.First(x => x is OracleOfZefra);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraath (Oracle Search)
            if (superheavySamurai == true
                && (hand.Count(x => x is Zefraath) == 0 || hand.Count(x => x is OracleOfZefra) == 0) 
                && deck.Any(x => x is Zefraath)
                && (deck.Any(x => x is ZefraniuSecretOfTheYangZing) && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || (deck.Any(x => x is OracleOfZefra) && deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))
                || (hand.Any(x => x is ZefraniuSecretOfTheYangZing) && deck.Any(x => x is OracleOfZefra) && deck.Any(x => x is StellarknightZefraxciton))))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraath (Oracle Search)
            if (superheavySamurai == true
                && hand.Count(x => x is Zefraath) == 0
                && deck.Any(x => x is Zefraath)
                && ((deck.Any(x => x is ZefraniuSecretOfTheYangZing) && deck.Any(x => x is OracleOfZefra) && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))   
                || (hand.Any(x => x is ZefraniuSecretOfTheYangZing) && deck.Any(x => x is OracleOfZefra) && deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7))))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }


            // Zefraath (Normal/Deneb)
            if (superheavySamurai == false
                && (hand.Count(x => x is Zefraath) == 0 || hand.Count(x => x is OracleOfZefra) == 0) 
                && (hand.Any(x => x is SatellarknightZefrathuban) || (hand.Any(x => x is SatellarknightDeneb) && deck.Any(x => x is SatellarknightZefrathuban)))
                && deck.Any(x => x is Zefraath))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraath (Skybridge, Note: No Vega)
            if (superheavySamurai == false
                && (hand.Count(x => x is Zefraath) == 0 || hand.Count(x => x is OracleOfZefra) == 0)
                && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb) 
                && (hand.Any(x => x is SatellarknightSkybridge) || (hand.Any(x => x is TellarknightLyran) && deck.Any(x => x is SatellarknightSkybridge)))
                && deck.Any(x => x is SatellarknightDeneb) 
                && deck.Any(x => x is SatellarknightZefrathuban)
                && deck.Any(x => x is Zefraath))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefrathuban Search
            if (hand.Count(x => x is Zefraath) == 0 
                && hand.Count(x => x is OracleOfZefra) == 0
                && hand.Any(x => x is StellarknightZefraxciton)
                && deck.Any(x => x is SatellarknightZefrathuban))
            {
                Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraxciton Search
            if (hand.Count(x => x is Zefraath) == 0
                && hand.Count(x => x is OracleOfZefra) == 0
                && hand.Any(x => x is SatellarknightZefrathuban)
                && deck.Any(x => x is StellarknightZefraxciton))
            {
                Card searchedCard = deck.First(x => x is StellarknightZefraxciton);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefrathuban Search #2
            if (deck.Any(x => x is SatellarknightZefrathuban))
            {
                Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraxciton Search #2
            if (deck.Any(x => x is StellarknightZefraxciton))
            {
                Card searchedCard = deck.First(x => x is StellarknightZefraxciton);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefracore Search
            if (deck.Any(x => x is ShaddollZefracore))
            {
                Card searchedCard = deck.First(x => x is ShaddollZefracore);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            // Zefraniu Search
            if (deck.Any(x => x is ZefraniuSecretOfTheYangZing))
            {
                Card searchedCard = deck.First(x => x is ZefraniuSecretOfTheYangZing);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy, searched);
            }

            return (hand, deck, gy, searched = false);
        }
    }
}