using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ArtifactScythe : Card
    {
        public ArtifactScythe()
        {
            Name = "Artifact Scythe";
            Type = "Fairy";
            Attribute = "Light";
            Level = 5;
            Attack = 2200;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 20292186;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}