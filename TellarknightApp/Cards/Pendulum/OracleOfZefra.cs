using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class OracleOfZefra : Card
    {
        public OracleOfZefra() 
        {
            Name = "Oracle of Zefra";
            Type = "Field Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Zefra" };
            Image = "./CardArt/Oracle.png";
            Id = 32354768;
        }

        public override (List<Card>, List<Card>, List<Card>) SearchDeck(List<Card> hand, List<Card> deck, List<Card> gy)
        {
            bool superheavySamurai = false;

            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                superheavySamurai = true;
            }

            // Zefraath (Oracle Search)
            if (superheavySamurai == true
                && hand.Count(x => x is Zefraath) == 0
                && deck.Any(x => x is Zefraath)
                && ((deck.Any(x => x is ZefraniuSecretOfTheYangZing) && ((gy.Any(x => x is ZefraProvidence) == false && deck.Any(x => x is ZefraProvidence) && deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)) || hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))
                || (hand.Any(x => x is ZefraniuSecretOfTheYangZing) && deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7))))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefraath (Normal/Deneb)
            if (superheavySamurai == false
                && hand.Count(x => x is Zefraath) == 0
                && (hand.Any(x => x is SatellarknightZefrathuban) || (hand.Any(x => x is SatellarknightDeneb) && deck.Any(x => x is SatellarknightZefrathuban)))
                && deck.Any(x => x is Zefraath))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefraath (Skybridge, Note: No Vega)
            if (superheavySamurai == false
                && hand.Count(x => x is Zefraath) == 0
                && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb)
                && (hand.Any(x => x is SatellarknightSkybridge) || (hand.Any(x => x is TellarknightLyran) && deck.Any(x => x is SatellarknightSkybridge)))
                && deck.Any(x => x is SatellarknightDeneb)
                && deck.Any(x => x is SatellarknightZefrathuban)
                && deck.Any(x => x is Zefraath))
            {
                Card searchedCard = deck.First(x => x is Zefraath);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefrathuban Search
            if (hand.Count(x => x is Zefraath) == 0
                && hand.Any(x => x is StellarknightZefraxciton)
                && deck.Any(x => x is SatellarknightZefrathuban))
            {
                Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefraxciton Search
            if (hand.Count(x => x is Zefraath) == 0
                && hand.Any(x => x is SatellarknightZefrathuban)
                && deck.Any(x => x is StellarknightZefraxciton))
            {
                Card searchedCard = deck.First(x => x is StellarknightZefraxciton);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefrathuban Search #2
            if (deck.Any(x => x is SatellarknightZefrathuban))
            {
                Card searchedCard = deck.First(x => x is SatellarknightZefrathuban);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefraxciton Search #2
            if (deck.Any(x => x is StellarknightZefraxciton))
            {
                Card searchedCard = deck.First(x => x is StellarknightZefraxciton);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefracore Search
            if (deck.Any(x => x is ShaddollZefracore))
            {
                Card searchedCard = deck.First(x => x is ShaddollZefracore);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            // Zefraniu Search
            if (deck.Any(x => x is ZefraniuSecretOfTheYangZing))
            {
                Card searchedCard = deck.First(x => x is ZefraniuSecretOfTheYangZing);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, gy);
            }

            return (hand, deck, gy);
        }
    }
}