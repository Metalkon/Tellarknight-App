using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class BystialBaldrake : Card
    {
        public BystialBaldrake()
        {
            Name = "Bystial Baldrake";
            Type = "Dragon";
            Attribute = "Dark";
            Level = 6;
            Attack = 2500;
            Defense = 2000;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 72656408;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}