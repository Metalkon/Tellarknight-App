using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MathmechDiameter : Card
    {
        public MathmechDiameter()
        {
            Name = "Mathmech Diameter";
            Type = "Cyberse";
            Attribute = "Light";
            Level = 4;
            Attack = 1000;
            Defense = 1500;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mathmech" };
            Id = 17946349;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}