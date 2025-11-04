using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RunickTip : Card
    {
        public RunickTip()
        {
            Name = "Runick Tip";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Runick" };
            Id = 31562086;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Runick + Level 4
            if (extraDeck.Any(x => x is GeriTheRunickFangs) && (hand.Any(x => x.Level == 4) || (hand.Any(x => x is StellarnovaBonds) && deck.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
                return localStats;
            }

            // Runick + Other Runick
            if (extraDeck.Count(x => x is GeriTheRunickFangs) >= 2 && hand.Any(x => x is not RunickTip && x.Archetype.Contains("Runick") && x.Type == "Spell" && x.Role == "Extender"))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}