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
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            // Add code to factor in that it can become level 4 with a normal summon, paired with extenders and tellar+spell/etc

            return localStats;
        }
    }
}