using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class Aratama : Card
    {
        public Aratama()
        {
            Name = "Aratama";
            Type = "Fiend";
            Attribute = "Dark";
            Level = 4;
            Attack = 800;
            Defense = 1800;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 16889337;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Sakitama In Hand/Deck
            if (hand.Any(x => x is Sakitama) || deck.Any(x => x is Sakitama))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}