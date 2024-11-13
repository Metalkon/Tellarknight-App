using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class KashtiraRiseheart : Card
    {
        public KashtiraRiseheart()
        {
            Name = "Kashtira Riseheart";
            Type = "Fire";
            Attribute = "Warrior";
            Level = 4;
            Attack = 1500;
            Defense = 2100;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 31149212;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Summon Itself With Any Other Kashtira Monster
            if (hand.Any(x => x.Archetype.Contains("Kashtira") && x.Level != null) && hand.Any(x => x != this && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            return localStats;
        }
    }
}