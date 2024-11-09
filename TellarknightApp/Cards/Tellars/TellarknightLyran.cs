using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class TellarknightLyran : Card
    {
        public TellarknightLyran() 
        {
            Name = "Tellarknight Lyran";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1200;
            Defense = 1600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Constellar" };
            Id = 79210531;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Lyran and Zefraath, Skybridge->Deneb->Thuban
            if (hand.Any(x => x is Zefraath) && hand.Count(x => x is SatellarknightZefrathuban) == 0
                && (hand.Any(x => x is SatellarknightSkybridge) || deck.Any(x => x is SatellarknightSkybridge))
                && deck.Any(x => x is SatellarknightDeneb))
            {
                localStats.AverageXyzTwoTellar = true;
                localStats.PendulumSummon = true;
                return localStats;
            }

            // Lyran + Any Other Lv4 "Tellar"
            if (hand.Any(x => x is not TellarknightLyran && x.Level == 4 
                && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // x2 Lyran, Continuous Spell Search
            if (hand.Count(x => x is TellarknightLyran) >= 2 
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights)))                
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // x2 Lyran, Skybridge->Vega
            if (hand.Count(x => x is TellarknightLyran) >= 2
                && (hand.Any(x => x is SatellarknightSkybridge) || deck.Any(x => x is SatellarknightSkybridge))
                && (hand.Any(x => x is SatellarknightVega) || deck.Any(x => x is SatellarknightVega)))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // ----------------

            // Lyran and Other Pend, Search Pend Tellar With Deneb
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales (High Search)
            if (deck.Any(x => x is SatellarknightSkybridge)
                && deck.Any(x => x is SatellarknightDeneb)
                && hand.Any(x => x.Scale <= 3) && deck.Any(x => x is StellarknightZefraxciton))
            {
                highScale = deck.First(x => x is StellarknightZefraxciton);
                if (hand.Any(x => x.Scale  <= 3 && x.Level != 4))
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else
                    lowScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
            }

            // Setup Scales (Low Search)
            if (deck.Any(x => x is SatellarknightSkybridge)
                && deck.Any(x => x is SatellarknightDeneb)
                && hand.Any(x => x.Scale >= 5) && deck.Any(x => x is SatellarknightZefrathuban))
            {
                lowScale = deck.First(x => x is SatellarknightZefrathuban);
                if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                else
                    highScale = hand.First(x => x.Scale >= 5 && x.Level == 4);
            }

            //Zefra Pend
            if (lowScale != null && highScale != null
                && deck.Any(x => x is SatellarknightSkybridge)
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