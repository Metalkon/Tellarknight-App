using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class PSYFramegearGamma : Card
    {
        public PSYFramegearGamma()
        {
            Name = "PSY-Framegear Gamma";
            Type = "Psychic";
            Attribute = "Light";
            Level = 2;
            Attack = 1000;
            Defense = 0;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 38814750;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}