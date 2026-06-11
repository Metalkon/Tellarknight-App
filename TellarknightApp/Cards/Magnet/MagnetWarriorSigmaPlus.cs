using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MagnetWarriorSigmaPlus : Card
    {
        public MagnetWarriorSigmaPlus()
        {
            Name = "Magnet Warrior Sigma Plus";
            Type = "Rock";
            Attribute = "Earth";
            Level = 4;
            Attack = 1800;
            Defense = 1500;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Magnet" };
            Id = 51826619;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}