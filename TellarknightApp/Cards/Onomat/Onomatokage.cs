using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Onomatokage : Card
    {
        public Onomatokage()
        {
            Name = "Onomatokage";
            Type = "Reptile";
            Attribute = "Dark";
            Level = 4;
            Attack = 1100;
            Defense = 1500;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat", "Dododo", "Gagaga", "Gogogo", "Zubaba" };
            Id = 55088578;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}