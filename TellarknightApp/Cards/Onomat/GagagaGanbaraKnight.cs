using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class GagagaGanbaraKnight : Card
    {
        public GagagaGanbaraKnight()
        {
            Name = "Gagaga Ganbara Knight";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 0;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat" };
            Id = 09491461;
            Image = $"./CardArt/{Id:D8}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}