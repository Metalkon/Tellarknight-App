using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class KashtiraOgre : Card
    {
        public KashtiraOgre()
        {
            Name = "Kashtira Ogre";
            Type = "Water";
            Attribute = "Psychic";
            Level = 7;
            Attack = 2800;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 94392192;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}