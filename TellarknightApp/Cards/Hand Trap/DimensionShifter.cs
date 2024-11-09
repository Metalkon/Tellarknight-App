using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class DimensionShifter : Card
    {
        public DimensionShifter()
        {
            Name = "Dimension Shifter";
            Type = "Spellcaster";
            Attribute = "Dark";
            Level = 6;
            Attack = 1200;
            Defense = 1200;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 91800273;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}