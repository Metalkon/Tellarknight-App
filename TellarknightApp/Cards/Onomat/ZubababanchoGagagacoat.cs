using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ZubababanchoGagagacoat : Card
    {
        public ZubababanchoGagagacoat()
        {
            Name = "Zubababancho Gagagacoat";
            Type = "Warrior";
            Attribute = "Earth";
            Level = 4;
            Attack = 1800;
            Defense = 100;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat", "Zubaba" };
            Id = 23720856;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Zubaba") || x.Archetype.Contains("Gagaga"))))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;

            }
            return localStats;
        }
    }
}