using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class KashtiraFenrir : Card
    {
        public KashtiraFenrir()
        {
            Name = "Kashtira Fenrir";
            Type = "Earth";
            Attribute = "Psychic";
            Level = 7;
            Attack = 2400;
            Defense = 2400;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 32909498;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Search Riseheart
            if (deck.Any(x => x is KashtiraRiseheart) && (hand.Any(x => x.Level == 4 && x is not PhotonThrasher) || (hand.Any(x => x is StellarnovaBonds) && deck.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))))
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