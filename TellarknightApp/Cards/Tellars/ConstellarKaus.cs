using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarKaus : Card
    {
        public ConstellarKaus()
        {
            Name = "Constellar Kaus";
            Type = "Beast-Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1800;
            Defense = 700;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 70908596;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}