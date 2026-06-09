using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Onomatopickup : Card
    {
        public Onomatopickup() 
        {
            Name = "Onomatopickup";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Onomat" };
            Id = 85119159;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}