using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class NodeRyzeal : Card
    {
        public NodeRyzeal()
        {
            Name = "Node Ryzeal";
            Type = "Thunder";
            Attribute = "Fire";
            Level = 4;
            Attack = 1400;
            Defense = 1600;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Ryzeal" };
            Id = 72238166;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}