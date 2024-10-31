using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightBetelgeuse : Card
    {
        public SatellarknightBetelgeuse() 
        {
            Name = "Satellarknight Betelgeuse";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 700;
            Defense = 1900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 26057276;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}