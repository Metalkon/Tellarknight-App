using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ZefraniuSecretOfTheYangZing : Card
    {
        public ZefraniuSecretOfTheYangZing() 
        {
            Name = "Zefraniu, Secret of the Yang Zing";
            Type = "Wyrm";
            Attribute = "Earth";
            Level = 6;
            Attack = 0;
            Defense = 2600;
            Scale = 7;
            Role = string.Empty;
            Archetype = new List<string> { "Yang Zing", "Zefra" };
            Id = 58990362;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}