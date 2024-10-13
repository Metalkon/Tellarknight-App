using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class Zefraath : Card
    {
        public Zefraath() 
        {
            Name = "Zefraath";
            Type = "Rock";
            Attribute = "Earth";
            Level = 11;
            Attack = 3450;
            Defense = 2950;
            Scale = 5;
            Role = string.Empty;
            Archetype = new List<string> { "Zefra" };
            Image = "./CardArt/Zefraath.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            bool superheavySamurai = false;

            // Note: due to large size of this method, return localstats at each stage in an appropriate order to improve performance.

            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                superheavySamurai = true;
            }
            
            // Zefraath + SHS (Oracle)
            if (superheavySamurai == true 
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                && (hand.Any(x => x is OracleOfZefra) || deck.Any(x => x is OracleOfZefra))
                && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))
            {
                localStats.OracleCombo = true;
                localStats.PendulumnSummon = true;
                if (hand.Any(x => x.Archetype.Contains("Zefra") && x.Archetype.Contains("Tellarknight") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Archetype.Contains("Tellarknight") && x.Level == 4))
                {
                    localStats.AverageXyzOneTellar = true;
                }
                return localStats;
            }

            // Zefraath + Deneb/Thuban (Zefracore)
            if ((hand.Any(x => x is SatellarknightZefrathuban) || (hand.Any(x => x is SatellarknightDeneb) 
                && deck.Any(x => x is SatellarknightZefrathuban)))
                && (deck.Any(x => x is ShaddollZefracore) || (hand.Any(x => x is ShaddollZefracore) && deck.Any(x => x is StellarknightZefraxciton))))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Skybridge->Deneb/Thuban (Zefracore)
            if (hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) 
                && hand.Any(x => x is SatellarknightSkybridge) 
                && deck.Any(x => x is SatellarknightDeneb)
                && deck.Any(x => x is SatellarknightZefrathuban)                
                && (deck.Any(x => x is ShaddollZefracore) || (hand.Any(x => x is ShaddollZefracore) && deck.Any(x => x is StellarknightZefraxciton))))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Zefrathuban (No Zefracore or pend7 in deck)
            // Add Code Later (Low Priority)

            // Zefraath + Thuban (No Zefracore)
            if (hand.Any(x => x is SatellarknightZefrathuban)
                && deck.Any(x => x is StellarknightZefraxciton)
                && hand.Any(x => x.Level == 4))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Zefraxciton
            if (hand.Any(x => x is StellarknightZefraxciton) 
                && deck.Any(x => x is SatellarknightZefrathuban)
                && hand.Any(x => x.Level == 4))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Zefraniu
            if (hand.Any(x => x is ZefraniuSecretOfTheYangZing)
                && (deck.Any(x => x is OracleOfZefra) || deck.Any(x => x is ZefraProvidence))
                && deck.Any(x => x.Archetype.Contains("Zefra") && x.Archetype.Contains("Tellarknight") && x.Level == 4)
                && (hand.Any(x => x is TellarknightLyran) || hand.Any(x => x is SatellarknightVega) || (hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) && hand.Any(x => x is ConstellarTellarknights))))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Zefraath/HighScale
            if ((hand.Count(x => x is Zefraath) >= 2 || hand.Any(x => x.Scale >= 5 && x is not Zefraath))
                && deck.Any(x => x is SatellarknightZefrathuban)
                && hand.Any(x => x.Level == 4 && (x.Scale <= 6 || x.Scale == null)))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            // Zefraath + Other Pend (Low Scale)
            if (hand.Any(x => x is not SatellarknightZefrathuban && x.Scale <= 3)
                && deck.Any(x => x is StellarknightZefraxciton)
                && hand.Any(x => x.Level == 4 && (x.Scale >= 4 || x.Scale == null)))
            {
                localStats.AverageXyzOneTellar = true;
                localStats.PendulumnSummon = true;
                return localStats;
            }

            return localStats;
        }
    }
}