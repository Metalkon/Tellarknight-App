using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RunickAllure : Card
    {
        public RunickAllure()
        {
            Name = "Runick Allure";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Runick" };
            Id = 29595202;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}