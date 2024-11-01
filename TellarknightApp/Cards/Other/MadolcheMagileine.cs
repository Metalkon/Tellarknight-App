using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MadolcheMagileine : Card
    {
        public MadolcheMagileine()
        {
            Name = "Madolche Magileine";
            Type = "Spellcaster";
            Attribute = "Earth";
            Level = 4;
            Attack = 1400;
            Defense = 1200;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 11868731;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Peting In Hand/Deck
            if (deck.Any(x => x is MadolchePetingcessoeur))
            {
                Random random = new Random();
                if ((hand.Count + gy.Count == 5) && hand.Any(x => x.Role == "Hand Trap" && x.Type != "Spell" && x.Type != "Trap") && random.Next(1, 11) <= 2)
                {
                    return localStats;
                }
                if ((hand.Count + gy.Count == 6) && hand.Any(x => x.Role == "Hand Trap" && x.Type != "Spell" && x.Type != "Trap") && random.Next(1, 11) <= 5)
                {
                    return localStats;
                }
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}