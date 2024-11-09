using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarSombre : Card
    {
        public ConstellarSombre()
        {
            Name = "Constellar Sombre";
            Type = "Fairy";
            Attribute = "Light";
            Level = 4;
            Attack = 1550;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 78358521;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}