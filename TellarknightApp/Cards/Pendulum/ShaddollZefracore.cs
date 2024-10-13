using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ShaddollZefracore : Card
    {
        public ShaddollZefracore() 
        {
            Name = "Shaddoll Zefracore";
            Type = "Rock";
            Attribute = "Dark";
            Level = 4;
            Attack = 450;
            Defense = 1950;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "Shaddoll", "Zefra" };
            Image = "./CardArt/Zefracore.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            return localStats;
        }
    }
}