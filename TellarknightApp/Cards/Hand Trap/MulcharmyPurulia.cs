using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MulcharmyPurulia : Card
    {
        public MulcharmyPurulia()
        {
            Name = "Mulcharmy Purulia";
            Type = "Aqua";
            Attribute = "Water";
            Level = 4;
            Attack = 100;
            Defense = 600;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 84192580;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}