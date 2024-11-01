using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MadolchePetingcessoeur : Card
    {
        public MadolchePetingcessoeur()
        {
            Name = "Madolche Petingcessoeur";
            Type = "Fairy";
            Attribute = "Earth";
            Level = 4;
            Attack = 1400;
            Defense = 1400;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 77848740;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Peting In Hand/Deck
            if (hand.Any(x => x != this && x.Level == 4))
            {
                Random random = new Random();
                if ((hand.Count + gy.Count == 5) && hand.Any(x => x.Role == "Hand Trap" && x.Type != "Spell" && x.Type != "Trap") && random.Next(1, 11) <= 2)
                {
                    return localStats;
                }
                if ((hand.Count + gy.Count== 6) && hand.Any(x => x.Role == "Hand Trap" && x.Type != "Spell" && x.Type != "Trap") && random.Next(1, 11) <= 5)
                {
                    return localStats;
                }
                localStats.AverageXyzNoTellar = true;

            }

            return localStats;
        }
    }
}