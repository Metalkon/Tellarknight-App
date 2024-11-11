using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonAtrii : Card
    {
        public CenturIonAtrii()
        {
            Name = "Centur-Ion Atrii";
            Type = "Dragon";
            Attribute = "Dark";
            Level = 4;
            Attack = 1800;
            Defense = 1400;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 96030710;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}