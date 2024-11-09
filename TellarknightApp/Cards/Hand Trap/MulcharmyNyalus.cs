using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MulcharmyNyalus : Card
    {
        public MulcharmyNyalus()
        {
            Name = "Mulcharmy Nyalus";
            Type = "Beast";
            Attribute = "Earth";
            Level = 4;
            Attack = 100;
            Defense = 600;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 87126721;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}