using TellarknightApp.Models;

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
            Id = 96223501;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card lowScale = null;
            Card highScale = null;

            // Setup Scales
            if (hand.Any(x => x.Scale <= 5))
            {
                lowScale = this;

                if (hand.Any(x => x.Scale  >= 5 && x.Level != 4))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level != 4);
                else if (hand.Any(x => x.Scale  >= 5 && x.Level == 4 && x is not ShaddollZefracore))
                    highScale = hand.First(x => x.Scale >= 5 && x.Level == 4 && x is not ShaddollZefracore);
                else if (hand.Any(x => x is ShaddollZefracore))
                    highScale = hand.First(x => x is ShaddollZefracore);
            }

            // Zefra Pend
            if (lowScale != null && highScale != null)
            {
                // At Least One Zefra Lv4 For Pend Summon (Other Could Be Normal Summoned)
                if ((highScale.Archetype.Contains("Shaddoll") || highScale.Archetype.Contains("Yang Zing"))
                    && hand.Count(x => x.Archetype.Contains("Zefra") && x.Level == 4 && x != lowScale && x != highScale) >= 1
                    && hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {
                    localStats.PendulumSummon = true;
                    return localStats;
                }

                // Tellar Pend
                if ((!lowScale.Archetype.Contains("Shaddoll") && !lowScale.Archetype.Contains("Yang Zing"))
                    && hand.Count(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Zefra")) && x.Level == 4 && x != lowScale && x != highScale) >= 1
                    && hand.Count(x => x.Level == 4 && x != lowScale && x != highScale) >= 2)
                {                    
                    localStats.PendulumSummon = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}