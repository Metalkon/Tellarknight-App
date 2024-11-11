using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CenturIonEmethVI : Card
    {
        public CenturIonEmethVI()
        {
            Name = "Centur-Ion Emeth VI";
            Type = "Machine";
            Attribute = "Earth";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Centur-Ion" };
            Id = 78888899;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}