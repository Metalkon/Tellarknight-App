using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class AbyssActorCurtainRaiser : Card
    {
        public AbyssActorCurtainRaiser()
        {
            Name = "Abyss Actor - Curtain Raiser";
            Type = "Fiend";
            Attribute = "Dark";
            Level = 4;
            Attack = 1100;
            Defense = 1000;
            Scale = 7;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 44179224;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales
            if (hand.Any(x => x.Scale <= 3))
            {
                highScale = this;

                if (hand.Any(x => x.Scale <= 3 && x.Level != 4))
                    highScale = hand.First(x => x.Scale <= 3 && x.Level != 4);
                else if (hand.Any(x => x.Scale <= 3 && x.Level == 4 && x.Archetype.Contains("Zefra") == false))
                    highScale = hand.First(x => x.Scale <= 3 && x.Level == 4);
            }

            // Pend
            if (lowScale != null && highScale != null)
            {
                if (hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzOneTellar = true;
                return localStats;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x != this && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}