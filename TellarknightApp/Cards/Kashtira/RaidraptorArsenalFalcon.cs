using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RaidraptorArsenalFalcon : Card
    {
        public RaidraptorArsenalFalcon()
        {
            Name = "Raidraptor - Arsenal Falcon";
            Type = "Dark";
            Attribute = "Winged Beast";
            Level = 7;
            Attack = 2500;
            Defense = 2000;
            Scale = null;
            Role = "Extra Deck";
            Archetype = new List<string> { "None" };
            Id = 96157835;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}