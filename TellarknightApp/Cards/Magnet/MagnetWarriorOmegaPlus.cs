using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MagnetWarriorOmegaPlus : Card
    {
        public MagnetWarriorOmegaPlus()
        {
            Name = "Magnet Warrior Omega Plus";
            Type = "Rock";
            Attribute = "Earth";
            Level = 4;
            Attack = 800;
            Defense = 1900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Magnet" };
            Id = 86289475;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            Card? rockMonster = hand.FirstOrDefault(x => x.Type.Contains("Rock") && x != this);

            if (rockMonster != null && hand.Any(x => x.Level == 4 && x != this && x != rockMonster))
            {
                localStats.AverageXyzNoTellar = true;
                if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))                    
                {
                    localStats.AverageXyzOneTellar = true;
                }
            }

            return localStats;
        }
    }
}