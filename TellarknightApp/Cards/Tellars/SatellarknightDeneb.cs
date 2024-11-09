using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SatellarknightDeneb : Card
    {
        public SatellarknightDeneb() 
        {
            Name = "Satellarknight Deneb";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1500;
            Defense = 1000;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Id = 75878039;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null; 
            Card highScale = null;

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

            return localStats;
        }
    }
}