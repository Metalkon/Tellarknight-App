using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RunickDispelling : Card
    {
        public RunickDispelling()
        {
            Name = "Runick Dispelling";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Runick" };
            Id = 66712905;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Runick + Level 4
            if (extraDeck.Any(x => x is GeriTheRunickFangs) && hand.Any(x => x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
            }
            // Runick + Other Runick
            if (extraDeck.Count(x => x is GeriTheRunickFangs) >= 2 && hand.Any(x => x is not RunickDispelling && x.Archetype.Contains("Runick") && x.Type == "Spell" && x.Role == "Extender"))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}