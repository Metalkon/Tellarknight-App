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
            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}