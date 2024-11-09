using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarTwinkle : Card
    {
        public ConstellarTwinkle()
        {
            Name = "Constellar Twinkle";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 35544402;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}