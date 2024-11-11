using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonGargoyleII : Card
    {
        public CenturIonGargoyleII()
        {
            Name = "Gargoyle II";
            Type = "Dragon";
            Attribute = "Dark";
            Level = 8;
            Attack = 2000;
            Defense = 3000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 97698279;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}