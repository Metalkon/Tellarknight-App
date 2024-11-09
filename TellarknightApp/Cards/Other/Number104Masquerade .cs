using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Number104Masquerade : Card
    {
        public Number104Masquerade()
        {
            Name = "\r\nNumber 104: Masquerade\r\n";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = null;
            Attack = 2700;
            Defense = 1200;
            Scale = null;
            Role = "Extra Deck";
            Archetype = new List<string> { "None" };
            Id = 02061963;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}