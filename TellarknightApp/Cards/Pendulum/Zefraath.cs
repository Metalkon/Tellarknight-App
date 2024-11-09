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
            Id = 29432356;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            bool superheavySamuraiFull = false;
            bool superheavySamurai = false;
            Card shsMonster = null;
            Card lowScale = null;
            Card highScale = null;

            // SHS Check
            if ((hand.Any(x => x is SuperheavySamuraiProdigyWakaushi) || (hand.Any(x => x is SuperheavySamuraiMotorbike) && deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                shsMonster = hand.First(x => x is SuperheavySamuraiProdigyWakaushi || x is SuperheavySamuraiMotorbike);
                if (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                {
                    superheavySamuraiFull = true;
                }
                else 
                {
                    superheavySamurai = true;
                }
            }
            
            // Zefraath + SHS (Oracle)
            if (superheavySamuraiFull == true 
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                && (hand.Any(x => x is OracleOfZefra) || deck.Any(x => x is OracleOfZefra) || gy.Any(x => x is OracleOfZefra))
                && (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) || deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))                
            {
                localStats.OracleCombo = true;
                localStats.PendulumSummon = true;
                return localStats;
            }

            // Zefraath + SHS (Oracle, No Booster)
            if (superheavySamurai == true
                && (hand.Any(x => x is ZefraniuSecretOfTheYangZing) || deck.Any(x => x is ZefraniuSecretOfTheYangZing))
                && (hand.Any(x => x is OracleOfZefra) || deck.Any(x => x is OracleOfZefra) || gy.Any(x => x is OracleOfZefra))
                && ((hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) && hand.Count(x => x.Level == 4 && x != shsMonster) >= 2) 
                || (deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4) && hand.Any(x => x.Level == 4 && x != shsMonster))))
            {
                localStats.OracleCombo = true;
                localStats.PendulumSummon = true;
                return localStats;
            }

            // Zefrathuban Hands
            if (hand.Any(x => x is SatellarknightZefrathuban))
            {
                // Thuban (Zefracore From Deck)
                if (hand.Any(x => x is SatellarknightZefrathuban)
                    && (hand.Any(x => x is ShaddollZefracore) || deck.Any(x => x is ShaddollZefracore)))
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }

                // Thuban (Without Zefracore)
                lowScale = hand.FirstOrDefault(x => x is SatellarknightZefrathuban);
                highScale = hand.FirstOrDefault(x => x is Zefraath);
                if (lowScale != null && highScale != null
                    && (deck.Any(x => x is StellarknightZefraxciton) && hand.Count(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Zefra")) && x != highScale && x != lowScale) >= 1)
                    || hand.Count(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Zefra")) && x != highScale && x != lowScale) >= 2)
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Deneb Zefrathuban Search
            if (hand.Any(x => x is SatellarknightDeneb) && hand.Count(x => x is SatellarknightZefrathuban) == 0
                && deck.Any(x => x is SatellarknightZefrathuban)
                && (deck.Any(x => x is ShaddollZefracore) || deck.Any(x => x is StellarknightZefraxciton)))
            {
                localStats.PendulumSummon = true;
                localStats.AverageXyzOneTellar = true;
                return localStats;
            }

            // Deneb Zefraxciton Search
            if (hand.Any(x => x is SatellarknightDeneb) && hand.Count(x => x is StellarknightZefraxciton) == 0
                && deck.Any(x => x is StellarknightZefraxciton)
                && deck.Any(x => x is SatellarknightZefrathuban))
            {
                localStats.PendulumSummon = true;
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Zefraxciton Hands
            if (hand.Any(x => x is SatellarknightZefrathuban))
            {
                // Zefraxciton (Thuban Deck and x1 Hand)
                lowScale = hand.FirstOrDefault(x => x is Zefraath);
                highScale = hand.FirstOrDefault(x => x is StellarknightZefraxciton);
                if (lowScale != null && highScale != null
                    && deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Count(x => x.Level == 4 && x != highScale && x != lowScale) >= 1)
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Zefraniu/Zefracore Hands
            if (hand.Any(x => x is ShaddollZefracore || x is ZefraniuSecretOfTheYangZing))
            {
                // Zefracore
                lowScale = hand.FirstOrDefault(x => x is Zefraath);
                highScale = hand.FirstOrDefault(x => x is ShaddollZefracore);
                if (lowScale != null && highScale != null
                    && deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Count(x => x.Level == 4 && x.Archetype.Contains("Zefra") && x != highScale && x != lowScale) >= 1
                    && hand.Count(x => x.Level == 4 && x != highScale && x != lowScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }

                // Zefraniu
                lowScale = hand.FirstOrDefault(x => x is Zefraath);
                highScale = hand.FirstOrDefault(x => x is ZefraniuSecretOfTheYangZing);
                if (lowScale != null && highScale != null
                    && deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Count(x => x.Level == 4 && x != highScale && x != lowScale) >= 1)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // x2 Zefraath Hands
            if (hand.Count(x => x is Zefraath) >= 2)
            {
                lowScale = hand.FirstOrDefault(x => x is Zefraath);
                highScale = hand.FirstOrDefault(x => x is Zefraath && x != lowScale);
                if (lowScale != null && highScale != null
                    && deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Count(x => x.Level == 4 && x != highScale && x != lowScale) >= 1)
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Skybridge In Hand
            if (hand.Any(x => x is SatellarknightSkybridge) 
                && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x.Scale == null & x is not SatellarknightDeneb && x is not TellarknightLyran)
                && deck.Any(x => x is SatellarknightDeneb))
            {
                Card tellar = hand.First(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x.Scale == null & x is not SatellarknightDeneb && x is not TellarknightLyran);

                if (deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Zefra")) && x.Level == 4 && x != tellar))                    
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }

                if (deck.Any(x => x is SatellarknightZefrathuban)
                    && deck.Any(x => x is StellarknightZefraxciton))
                {
                    localStats.AverageXyzTwoTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Lyran Search Skybridge
            if (hand.Any(x => x is TellarknightLyran) 
                && deck.Any(x => x is SatellarknightSkybridge)
                && deck.Any(x => x is SatellarknightDeneb)
                && deck.Any(x => x is SatellarknightZefrathuban || x is StellarknightZefraxciton))
            {
                Card lyran = hand.First(x => x is TellarknightLyran);

                if (deck.Any(x => x is SatellarknightZefrathuban)
                    && hand.Any(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Zefra")) && x.Level == 4 && x != lyran))
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }

                if (deck.Any(x => x is SatellarknightZefrathuban)
                    && deck.Any(x => x is StellarknightZefraxciton))
                {
                    localStats.AverageXyzTwoTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Generic Lv4 Low Scale
            if (hand.Any(x => x is SuperheavySamuraiMonkBigBenkei) && deck.Count(x => x is SuperheavySamuraiMonkBigBenkei) == 0)
            {
                lowScale = hand.First(x => x is SuperheavySamuraiMonkBigBenkei);
            }
            else
            {
                lowScale = hand.FirstOrDefault(x => x.Scale <= 3 && x.Archetype.Contains("Zefra") == false);
            }
            highScale = hand.FirstOrDefault(x => x is Zefraath);
            if (lowScale != null && highScale != null)
            {
                if (deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7) && hand.Any(x => x.Level == 4 && x != lowScale && x != highScale))
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
                if (deck.Count(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7) == 0 && hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Generic Lv4 Low Scale
            if (hand.Any(x => x is SuperheavySamuraiMonkBigBenkei) && deck.Count(x => x is SuperheavySamuraiMonkBigBenkei) == 0)
            {
                lowScale = hand.First(x => x is SuperheavySamuraiMonkBigBenkei);
            }
            else
            {
                lowScale = hand.FirstOrDefault(x => x.Scale <= 3 && x.Archetype.Contains("Zefra") == false);
            }
            highScale = hand.FirstOrDefault(x => x is Zefraath);
            if (lowScale != null && highScale != null)
            {
                if (deck.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7) && hand.Any(x => x.Level == 4 && x != lowScale && x != highScale))
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
                if (deck.Count(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x.Scale == 7) == 0 && hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Generic Lv4 High Scale
            lowScale = hand.FirstOrDefault(x => x is Zefraath);
            highScale = hand.FirstOrDefault(x => x.Scale >= 5 && x.Archetype.Contains("Zefra") == false);
            if (lowScale != null && highScale != null)
            {
                if (deck.Any(x => x is SatellarknightZefrathuban) && hand.Any(x => x.Level == 4 && x != lowScale && x != highScale))
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Zefraniu Scale
            lowScale = hand.FirstOrDefault(x => x is Zefraath);
            highScale = hand.FirstOrDefault(x => x is ZefraniuSecretOfTheYangZing);
            if (lowScale != null && highScale != null)
            {
                if (deck.Any(x => x is SatellarknightZefrathuban) && hand.Any(x => x.Level == 4 && x != lowScale && x != highScale))
                {
                    localStats.AverageXyzOneTellar = true;
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}