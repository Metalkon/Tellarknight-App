using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightZefrathuban : Card
    {
        public SatellarknightZefrathuban() 
        {
            Name = "Satellarknight Zefrathuban";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 0;
            Defense = 2100;
            Scale = 1;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Zefra" };
            Image = "./CardArt/Zefrathuban.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {


            return localStats;
        }
    }
}