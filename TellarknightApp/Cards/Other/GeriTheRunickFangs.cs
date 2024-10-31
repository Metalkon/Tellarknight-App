using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class GeriTheRunickFangs : Card
    {
        public GeriTheRunickFangs()
        {
            Name = "Geri the Runick Fangs";
            Type = "Beast";
            Attribute = "Dark";
            Level = 4;
            Attack = 0;
            Defense = 1000;
            Scale = null;
            Role = "Extra Deck";
            Archetype = new List<string> { "Runick" };
            Id = 28373620;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}