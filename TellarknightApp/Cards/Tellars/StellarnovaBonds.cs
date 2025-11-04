using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class StellarnovaBonds : Card
    {
        public StellarnovaBonds() 
        {
            Name = "Stellarnova Bonds";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Id = 99999999;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Summon Castor
            if (deck.Any(x => x is not ConstellarCastor && x.Level == 4 && x.Archetype.Contains("Constellar"))
                && deck.Any(x => x is ConstellarCastor))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Summon Cygnian
            if (deck.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) 
                && deck.Any(x => x is TellarknightCygnian) && deck.Count(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) >= 2)
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Summon Cygnian (Tellar CT Spell)
            if (hand.Any(x => x is TellarknightCygnian)
                && deck.Any(x => x is TellarknightCygnian)
                && deck.Any(x => x is not SatellarknightDeneb && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Summon Deneb (Tellar CT Spell)
            if (hand.Any(x => x is ConstellarTellarknights)
                && deck.Any(x => x is SatellarknightDeneb)
                && deck.Any(x => x is not SatellarknightDeneb && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Summon Unuk (Tellar CT Spell)
            if (hand.Any(x => x is ConstellarTellarknights)
                && deck.Any(x => x is SatellarknightUnukalhai)
                && deck.Any(x => x is not SatellarknightUnukalhai && x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Summon Any Tellar
            if (deck.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4)
                && hand.Any(x => x.Level == 4))
            {
                if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
                {
                    localStats.AverageXyzTwoTellar = true;
                }
                else
                {
                    localStats.AverageXyzOneTellar = true;
                }
            }

            return localStats;
        }
    }
}