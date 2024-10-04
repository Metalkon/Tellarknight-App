using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class Zefraath : Card
    {
        public Zefraath() 
        {
            Name = "Zefraath";
            Type = "Rock";
            Attribute = "Earth";
            Level = 11;
            Attack = 3450;
            Defense = 2950;
            Scale = 5;
            Role = string.Empty;
            Archetype = new List<string> { "Zefra" };
            Image = "./CardArt/Zefraath.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {


            return localStats;
        }
    }
}