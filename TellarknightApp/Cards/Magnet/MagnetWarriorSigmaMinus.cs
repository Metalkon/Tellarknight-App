using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MagnetWarriorSigmaMinus : Card
    {
        public MagnetWarriorSigmaMinus()
        {
            Name = "Magnet Warrior Sigma Minus";
            Type = "Rock";
            Attribute = "Earth";
            Level = 4;
            Attack = 1500;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Magnet" };
            Id = 87814728;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}