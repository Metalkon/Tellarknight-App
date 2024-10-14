using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightSkybridge : Card
    {
        public SatellarknightSkybridge() 
        {
            Name = "Satellarknight Skybridge";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Skybridge.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Two Tellars -> Skybridge -> Vega

            // Two Tellars -> Skybridge -> Lyran

            // Unuk -> Skybridge -> Altair / Lyran

            // Unuk -> Skybridge -> Lyran -> Cont. Spell

            // Deneb -> Skybridge -> Vega / Lyran+

            // Deneb -> Skybridge -> Lyran -> Cont. Spell


            return localStats;
        }
    }
}