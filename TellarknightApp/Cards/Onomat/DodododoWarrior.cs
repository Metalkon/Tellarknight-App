using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class DodododoWarrior : Card
    {
        public DodododoWarrior()
        {
            Name = "Dodododo Warrior";
            Type = "Warrior";
            Attribute = "Earth";
            Level = 6;
            Attack = 2300;
            Defense = 900;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Onomat", "Dododo" };
            Id = 62880279;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Glove
            if (deck.Any(x => x is DodododwarfGogogoglove))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
            }

            // Extender And Normal Summon Level 4
            if (deck.Any(x => x.Archetype.Contains("Dododo")) && hand.Any(x => x != this && x.Level == 4) == true)
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
            }

            // Onomatokage
            if (hand.Any(x => x is Onomatokage) || deck.Any(x => x is Onomatokage))
            {
                if (hand.Any(x => x is DominusPurge) && (hand.Count + gy.Count == 6))
                {
                    Random random = new Random();
                    if (random.Next(1, 11) >= 6)
                    {
                        return localStats;
                    }
                }
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
                {
                    localStats.AverageXyzOneTellar = true;
                    return localStats;
                }
            }

            return localStats;
        }
    }
}