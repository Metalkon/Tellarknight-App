using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiSoulgaiaBooster : Card
    {
        public SuperheavySamuraiSoulgaiaBooster() 
        {
            Name = "Superheavy Samurai Soulgaia Booster";
            Type = "Machine";
            Attribute = "Earth";
            Level = 4;
            Attack = 0;
            Defense = 0;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "SHS" };
            Id = 56727340;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || hand.Any(x => x is SuperheavySamuraiMotorbike))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}