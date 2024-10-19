using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightZefrathuban : Card
    {
        public SatellarknightZefrathuban() 
        {
            Name = "Satellarknight Zefrathuban";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 0;
            Defense = 2100;
            Scale = 1;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight", "Zefra" };
            Image = "./CardArt/Zefrathuban.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Pendulum Summon
            if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
            {
                // Temporarily disable scale
                if (hand.Any(x => x.Scale >= 5 && x.Level != 4))
                {
                    hand.FirstOrDefault(x => x.Scale >= 5 && x.Level != 4).Enabled = false;
                }
                else
                {
                    hand.FirstOrDefault(x => x.Scale >= 5 && x.Level == 4).Enabled = false;
                }

                // Zefraxciton/Random Scale
                if (hand.Any(x => x.Enabled == false && x is not ShaddollZefracore && x is not ZefraniuSecretOfTheYangZing)
                    && (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Tellarknight")) && x.Level == 4) >= 2) 
                    || (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Tellarknight")) && x.Level == 4) == 1 
                    && hand.Any(x => (!x.Archetype.Contains("Zefra") || !x.Archetype.Contains("Tellarknight")) && x.Level == 4)))
                {
                    localStats.PendulumSummon = true;
                    foreach (Card card in hand)
                    {
                        card.Enabled = true;
                    }
                    return localStats;
                }

                // Zefracore Scale
                if (hand.Any(x => x.Enabled == false && x is ShaddollZefracore)
                    && (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Shaddoll")) && x.Level == 4) >= 2)
                    || (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Shaddoll")) && x.Level == 4) == 1
                    && hand.Any(x => (!x.Archetype.Contains("Zefra") || !x.Archetype.Contains("Shaddoll")) && x.Level == 4)))
                {
                    localStats.PendulumSummon = true;
                    foreach (Card card in hand)
                    {
                        card.Enabled = true;
                    }
                    return localStats;
                }

                // Zefracore Scale
                if (hand.Any(x => x.Enabled == false && x is ZefraniuSecretOfTheYangZing)
                    && (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Yang Zing")) && x.Level == 4) >= 2)
                    || (hand.Count(x => (x.Archetype.Contains("Zefra") || x.Archetype.Contains("Yang Zing")) && x.Level == 4) == 1
                    && hand.Any(x => (!x.Archetype.Contains("Zefra") || !x.Archetype.Contains("Yang Zing")) && x.Level == 4)))
                {
                    localStats.PendulumSummon = true;
                    foreach (Card card in hand)
                    {
                        card.Enabled = true;
                    }
                    return localStats;

                }
            }

            return localStats;
        }
    }
}