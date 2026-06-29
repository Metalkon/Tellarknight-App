using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ZubababaKnight : Card
    {
        public ZubababaKnight()
        {
            Name = "Zubababa Knight";
            Type = "Warrior";
            Attribute = "Earth";
            Level = 3;
            Attack = 1600;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Onomat", "Zubaba" };
            Id = 62006866;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            if (hand.Any(x => x is Onomatokage || x is ZubababanchoGagagacoat) || deck.Any(x => x is Onomatokage || x is ZubababanchoGagagacoat))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;

            }

            return localStats;
        }
    }
}