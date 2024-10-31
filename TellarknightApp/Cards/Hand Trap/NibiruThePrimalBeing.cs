using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class NibiruThePrimalBeing : Card
    {
        public NibiruThePrimalBeing()
        {
            Name = "Nibiru, the Primal Being";
            Type = "Rock";
            Attribute = "Light";
            Level = 11;
            Attack = 3000;
            Defense = 600;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 27204311;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}