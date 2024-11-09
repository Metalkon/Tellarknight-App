using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class GhostSisterSpookyDogwood : Card
    {
        public GhostSisterSpookyDogwood()
        { 
            Name = "Ghost Sister & Spooky Dogwood";
            Type = "Zombie";
            Attribute = "Water";
            Level = 3;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 60643553;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}