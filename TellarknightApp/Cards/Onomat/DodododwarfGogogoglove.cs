using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class DodododwarfGogogoglove : Card
    {
        public DodododwarfGogogoglove()
        {
            Name = "Dodododwarf Gogogoglove";
            Type = "Rock";
            Attribute = "Earth";
            Level = 4;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat", "Dododo", "Gogogo" };
            Id = 59724555;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Zubaba") || x.Archetype.Contains("Gagaga"))))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}