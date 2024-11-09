using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TherionDiscolosseum : Card
    {
        public TherionDiscolosseum()
        {
            Name = "Therion Discolosseum";
            Type = "Field Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 84792926;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}