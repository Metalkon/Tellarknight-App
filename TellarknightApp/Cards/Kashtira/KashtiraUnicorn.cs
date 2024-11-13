using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class KashtiraUnicorn : Card
    {
        public KashtiraUnicorn()
        {
            Name = "Kashtira Unicorn";
            Type = "Wind";
            Attribute = "Psychic";
            Level = 7;
            Attack = 2500;
            Defense = 2100;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Kashtira" };
            Id = 68304193;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Search Theosis
            if (deck.Any(x => x is Kashtiratheosis))
            {
                // One Card Combo (Fenrir->Riseheart->Arsenal Falcon->Blackwing)
                if (deck.Any(x => x is KashtiraFenrir) 
                    && (hand.Any(x => x is KashtiraRiseheart) || deck.Any(x => x is KashtiraRiseheart))
                    && extraDeck.Any(x => x is RaidraptorArsenalFalcon)
                    && (hand.Any(x => x is BlackwingZephyrostheElite) || deck.Any(x => x is BlackwingZephyrostheElite)))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                    return localStats;
                }

                // Search Riseheart as Extender
                if (deck.Any(x => x is KashtiraRiseheart) && hand.Any(x => x.Level == 4 && x is not PhotonThrasher))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                    return localStats;
                }

                // Falcon->Blackwing For Extender
                if (deck.Any(x => x.Archetype.Contains("Kashtira") && x.Level == 7 && x.Attribute != this.Attribute)
                    && hand.Any(x => x.Level == 4 && x is not PhotonThrasher))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                    return localStats;
                }
            }

            // Search Planet -> Riseheart
            if (gy.Any(x => x is PressuredPlanetWraitsoth) == false && deck.Any(x => x is PressuredPlanetWraitsoth)
                && deck.Any(x => x is KashtiraRiseheart) 
                && hand.Any(x => x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            // Search Birth
            if (deck.Any(x => x is KashtiraBirth)
                && (hand.Count(x => x.Archetype.Contains("Kashtira") && x.Level == 7) >= 2
                && hand.Count(x => x.Archetype.Contains("Kashtira") && x.Level != null) >= 3)
                && hand.Any(x => x.Level == 4)
                && extraDeck.Any(x => x is RaidraptorArsenalFalcon) && deck.Any(x => x is BlackwingZephyrostheElite))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}