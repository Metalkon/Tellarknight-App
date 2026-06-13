using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MitsurugiPrayers : Card
    {
        public MitsurugiPrayers() 
        {
            Name = "Mitsurugi Prayers";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Mitsurugi" };
            Id = 45171524;
            Image = $"./CardArt/{Id:D8}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}