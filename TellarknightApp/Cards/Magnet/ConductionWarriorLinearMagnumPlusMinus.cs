using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConductionWarriorLinearMagnumPlusMinus : Card
    {
        public ConductionWarriorLinearMagnumPlusMinus()
        {
            Name = "Conduction Warrior Linear Magnum Plus Minus";
            Type = "Rock";
            Attribute = "Earth";
            Level = 7;
            Attack = 2700;
            Defense = 1300;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Magnet" };
            Id = 44839512;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            int totalCount = hand.Count(x => x.Archetype.Contains("Magnet") && x.Level == 4) + deck.Count(x => x.Archetype.Contains("Magnet") && x.Level == 4);
            bool epsilon = hand.Any(x => x is DodododoWarrior) || deck.Any(x => x is EpsilonTheMagnetWarrior);
            bool sigmaPlus = hand.Any(x => x is MagnetWarriorSigmaPlus) || deck.Any(x => x is MagnetWarriorSigmaPlus);
            bool omegaPlus = hand.Any(x => x is MagnetWarriorOmegaPlus) || deck.Any(x => x is MagnetWarriorOmegaPlus); 

            if (totalCount >= 2)
            {
                if (epsilon && sigmaPlus && deck.Any(x => x.Level == 4 && x.Archetype.Contains("Magnet")))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                }

                if (sigmaPlus == true && hand.Any(x => x.Level == 4))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                }

                if (omegaPlus == true && hand.Any(x => x.Level == 4))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
                    {
                        localStats.AverageXyzOneTellar = true;
                    }
                }
            }

            return localStats;
        }
    }
}