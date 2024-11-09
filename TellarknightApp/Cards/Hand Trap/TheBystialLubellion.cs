using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class TheBystialLubellion : Card
    {
        public TheBystialLubellion()
        {
            Name = "The Bystial Lubellion";
            Type = "Dragon";
            Attribute = "Light";
            Level = 8;
            Attack = 2500;
            Defense = 3000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 32731036;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}