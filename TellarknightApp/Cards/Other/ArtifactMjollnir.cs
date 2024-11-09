using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ArtifactMjollnir : Card
    {
        public ArtifactMjollnir()
        {
            Name = "Artifact Mjollnir";
            Type = "Fairy";
            Attribute = "Light";
            Level = 5;
            Attack = 2200;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 80237445;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}