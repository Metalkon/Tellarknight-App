using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiMotorbike : Card
    {
        public SuperheavySamuraiMotorbike() 
        {
            Name = "Superheavy Samurai Motorbike";
            Type = "Machine";
            Attribute = "Earth";
            Level = 2;
            Attack = 800;
            Defense = 1200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "SHS" };
            Image = "./CardArt/Motorbike.png";
            Id = 83334932;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // SHS Check
            if (deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            // Extender Play
            if (hand.Any(x => x.Role.Contains("Extender") && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            // Tellar Spell
            if (hand.Any(x => x is ConstellarTellarknights) && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                localStats.AverageXyzOneTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}