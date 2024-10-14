using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class StellarknightZefraxciton : Card
    {
        public StellarknightZefraxciton() 
        {
            Name = "Stellarknight Zefraxciton";
            Type = "Fiend";
            Attribute = "Light";
            Level = 4;
            Attack = 1900;
            Defense = 0;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Zefra" };
            Image = "./CardArt/Zefraxciton.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {


            return localStats;
        }
    }
}