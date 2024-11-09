using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class NewCard : Card
    {
        public NewCard() 
        {
            Name = "Card";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 1300;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Image = "./CardArt/CardBack.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {


            return localStats;
        }
    }
}