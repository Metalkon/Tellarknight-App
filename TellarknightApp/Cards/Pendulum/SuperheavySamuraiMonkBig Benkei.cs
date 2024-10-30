using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiMonkBigBenkei : Card
    {
        public SuperheavySamuraiMonkBigBenkei() 
        {
            Name = "Superheavy Samurai Monk Big Benkei";
            Type = "Machine";
            Attribute = "Earth";
            Level = 8;
            Attack = 1000;
            Defense = 3500;
            Scale = 1;
            Role = string.Empty;
            Archetype = new List<string> { "SHS" };
            Image = "./CardArt/Benkei.png";
            Id = 19510093;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {


            return localStats;
        }
    }
}