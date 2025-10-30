using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarCastor : Card
    {
        public ConstellarCastor()
        {
            Name = "Constellar Castor";
            Type = "Fairy";
            Attribute = "Light";
            Level = 4;
            Attack = 1700;
            Defense = 600;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 99999997;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null;
            Card highScale = null;

            if (deck.Any(x => x.Archetype.Contains("Zefra") && x.Archetype.Contains("Tellarknight")) && deck.Any(x => x is TellarknightCygnian))
            {
                // Setup Scales (High Search)
                if (hand.Any(x => x.Scale <= 3) && deck.Any(x => x is StellarknightZefraxciton))
                {
                    highScale = deck.First(x => x is StellarknightZefraxciton);
                    if (hand.Any(x => x.Scale  <= 3 && x.Level != 4))
                        lowScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                    else
                        lowScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
                }

                // Setup Scales (Low Search)
                if (hand.Any(x => x.Scale >= 5) && deck.Any(x => x is SatellarknightZefrathuban))
                {
                    lowScale = deck.First(x => x is SatellarknightZefrathuban);
                    if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
                        highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                    else
                        highScale = hand.First(x => x.Scale >= 5 && x.Level == 4);
                }

                //Zefra Pend
                if (lowScale != null && highScale != null
                    && (lowScale.Archetype.Contains("Zefra") || highScale.Archetype.Contains("Zefra")))
                {
                    // Zefra Tellar and Neutral Scales
                    if ((!highScale.Archetype.Contains("Shaddoll") && !highScale.Archetype.Contains("Yang Zing"))
                        && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x != this && x != lowScale && x != highScale))
                    {
                        localStats.AverageXyzTwoTellar = true;
                        localStats.PendulumSummon = true;
                        return localStats;
                    }
                    // Weird Zefra Scale
                    if ((highScale.Archetype.Contains("Shaddoll") || highScale.Archetype.Contains("Yang Zing"))
                        && hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x != this && x != lowScale && x != highScale))
                    {
                        localStats.AverageXyzOneTellar = true;
                        localStats.PendulumSummon = true;
                        return localStats;
                    }
                }
            }

            // Castor + Deck Summon
            if (deck.Any(x => x is not ConstellarCastor && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}