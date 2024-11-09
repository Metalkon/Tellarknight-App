using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class GhostMournerMoonlitChill : Card
    {
        public GhostMournerMoonlitChill()
        {
            Name = "Ghost Mourner & Moonlit Chill";
            Type = "Zombie";
            Attribute = "Wind";
            Level = 3;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 52038441;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}