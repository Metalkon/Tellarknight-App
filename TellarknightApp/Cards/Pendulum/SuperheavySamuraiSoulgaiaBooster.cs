using TellarknightApp.Models;
using TellarknightApp.Services;

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
            Image = "./CardArt/Booster.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Add code for an shs normal summon when it bricks with benkei, equip and summon off wakaushi/motorbike

            return localStats;
        }
    }
}