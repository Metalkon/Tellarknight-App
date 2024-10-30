using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiProdigyWakaushi : Card
    {
        public SuperheavySamuraiProdigyWakaushi() 
        {
            Name = "Superheavy Samurai Prodigy Wakaushi";
            Type = "Machine";
            Attribute = "Dark";
            Level = 4;
            Attack = 1000;
            Defense = 1500;
            Scale = 8;
            Role = string.Empty;
            Archetype = new List<string> { "SHS" };
            Id = 82112494;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}