using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SkullMeister : Card
    {
        public SkullMeister()
        {
            Name = "Skull Meister";
            Type = "Fiend";
            Attribute = "Dark";
            Level = 4;
            Attack = 1700;
            Defense = 400;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 67750322;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}