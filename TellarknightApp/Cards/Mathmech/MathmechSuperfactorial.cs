using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MathmechSuperfactorial : Card
    {
        public MathmechSuperfactorial()
        {
            Name = "Mathmech Superfactorial";
            Type = "Trap";
            Attribute = string.Empty;
            Level = 4;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mathmech" };
            Id = 87804365;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}