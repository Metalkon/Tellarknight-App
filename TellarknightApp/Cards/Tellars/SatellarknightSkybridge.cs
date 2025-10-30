using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightSkybridge : Card
    {
        public SatellarknightSkybridge() 
        {
            Name = "Satellarknight Skybridge";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 18205590;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lyran = deck.FirstOrDefault(x => x is TellarknightLyran);

            // Two Tellars -> Skybridge -> Lyran
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) >= 2
                && hand.Count(x => x is TellarknightLyran) == 0
                && deck.Any(x => x is TellarknightLyran))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Two Tellars -> Skybridge -> Vega
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) >= 2
                && hand.Count(x => x is SatellarknightVega) == 0
                && deck.Any(x => x is SatellarknightVega))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Cygnian -> Skybridge -> Vega
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Count(x => x is TellarknightCygnian) == 1
                && deck.Any(x => x is SatellarknightVega)
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightVega && x is not TellarknightCygnian))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Deneb -> Skybridge -> Vega
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Count(x => x is SatellarknightDeneb) == 1
                && deck.Any(x => x is SatellarknightVega)
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightVega && x is not SatellarknightDeneb))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Cygnian -> Skybridge -> Lyran -> Cont. Spell
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Any(x => x is TellarknightCygnian)
                && lyran != null
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not TellarknightCygnian && x != lyran))

            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Deneb -> Skybridge -> Lyran -> Cont. Spell
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Any(x => x is SatellarknightDeneb)
                && lyran != null
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb && x != lyran))

            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Unuk -> Skybridge -> Altair / Lyran
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Any(x => x is SatellarknightUnukalhai)
                && deck.Any(x => x is SatellarknightAltair)
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightUnukalhai && x is not SatellarknightAltair))

            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Unuk -> Skybridge -> Lyran -> Cont. Spell
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) == 1
                && hand.Any(x => x is SatellarknightUnukalhai)
                && lyran != null
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightUnukalhai && x != lyran))

            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Search Pend Tellar With Deneb
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales (High Search, Cygnian)
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not TellarknightCygnian) >= 1
                && deck.Any(x => x is TellarknightCygnian)
                && hand.Any(x => x.Scale <= 3) && deck.Any(x => x is StellarknightZefraxciton))
            {
                highScale = deck.First(x => x is StellarknightZefraxciton);
                if (hand.Any(x => x.Scale  <= 3 && x.Level != 4))
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
            }

            // Setup Scales (High Search, Deneb)
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb) >= 1
                && deck.Any(x => x is SatellarknightDeneb)
                && hand.Any(x => x.Scale <= 3) && deck.Any(x => x is StellarknightZefraxciton))
            {
                highScale = deck.First(x => x is StellarknightZefraxciton);
                if (hand.Any(x => x.Scale  <= 3 && x.Level != 4))
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
            }

            // Setup Scales (Low Search, Cygnian)
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not TellarknightCygnian) >= 1
                && deck.Any(x => x is TellarknightCygnian)
                && hand.Any(x => x.Scale >= 5) && deck.Any(x => x is SatellarknightZefrathuban))
            {
                lowScale = deck.First(x => x is SatellarknightZefrathuban);
                if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                else
                    highScale = hand.First(x => x.Scale >= 5 && x.Level == 4);
            }

            // Setup Scales (Low Search, Deneb)
            if (hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb) >= 1
                && deck.Any(x => x is SatellarknightDeneb)
                && hand.Any(x => x.Scale >= 5) && deck.Any(x => x is SatellarknightZefrathuban))
            {
                lowScale = deck.First(x => x is SatellarknightZefrathuban);
                if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                else
                    highScale = hand.First(x => x.Scale >= 5 && x.Level == 4);
            }

            // Zefra Pend (Cygnian)
            if (lowScale != null && highScale != null
                && hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not TellarknightCygnian) >= 1
                && deck.Any(x => x is TellarknightCygnian)
                && (lowScale.Archetype.Contains("Zefra") || highScale.Archetype.Contains("Zefra")))
            {
                // Zefra Tellar and Neutral Scales (Tellar Locked)
                if ((!highScale.Archetype.Contains("Shaddoll") && !highScale.Archetype.Contains("Yang Zing"))
                    && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x != this && x != lowScale && x != highScale))
                {
                    localStats.AverageXyzTwoTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Zefra Pend (Deneb)
            if (lowScale != null && highScale != null
                && hand.Count(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x is not SatellarknightDeneb) >= 1
                && deck.Any(x => x is SatellarknightDeneb)
                && (lowScale.Archetype.Contains("Zefra") || highScale.Archetype.Contains("Zefra")))
            {
                // Zefra Tellar and Neutral Scales (Tellar Locked)
                if ((!highScale.Archetype.Contains("Shaddoll") && !highScale.Archetype.Contains("Yang Zing"))
                    && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x != this && x != lowScale && x != highScale))
                {
                    localStats.AverageXyzTwoTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}