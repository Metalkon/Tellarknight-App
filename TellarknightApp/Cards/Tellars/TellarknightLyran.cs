using TellarknightApp.Models;
using TellarknightApp.Services;

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
            Image = "./CardArt/Lyran.png";
            Id = 79210531;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Lyran + Any Other Lv4 "Tellar"
            if (hand.Any(x => x is not TellarknightLyran && x.Level == 4 
                && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // x2 Lyran, Continuous Spell Search
            if (hand.Count(x => x is TellarknightLyran) >= 2 
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights)))                
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // x2 Lyran, Skybridge->Vega
            if (hand.Count(x => x is TellarknightLyran) >= 2
                && (hand.Any(x => x is SatellarknightSkybridge) || deck.Any(x => x is SatellarknightSkybridge))
                && (hand.Any(x => x is SatellarknightVega) || deck.Any(x => x is SatellarknightVega)))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Lyran and Zefraath, Skybridge->Deneb->Thuban
            if (hand.Any(x => x is Zefraath) && hand.Count(x => x is SatellarknightZefrathuban) == 0
                && deck.Any(x => x is SatellarknightSkybridge) 
                && deck.Any(x => x is SatellarknightDeneb))
            {
                localStats.AverageXyzTwoTellar = true;
                localStats.ZefraathAndThuban = true;
            }
            // Lyran and Other Pend, Search Pend Tellar With Deneb
            // Add Code

            return localStats;
        }
    }
}