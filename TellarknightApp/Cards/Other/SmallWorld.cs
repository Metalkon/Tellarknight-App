using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SmallWorld : Card
    {
        public SmallWorld() 
        {
            Name = "Small World";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 89558743;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>) SearchDeck(List<Card> hand, List<Card> deck, List<Card> gy)
        {
            // Add Small World Code

            return (hand, deck, gy);
        }
    }
}