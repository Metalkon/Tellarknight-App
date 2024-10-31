using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class GhostReaperWinterCherries : Card
    {
        public GhostReaperWinterCherries()
        {
            Name = "Ghost Reaper & Winter Cherries";
            Type = "Zombie";
            Attribute = "Dark";
            Level = 3;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 62015408;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}