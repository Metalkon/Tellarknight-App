using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class PSYFrameDriver : Card
    {
        public PSYFrameDriver()
        {
            Name = "PSY-Frame Driver";
            Type = "Psychic";
            Attribute = "Light";
            Level = 6;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 49036338;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}