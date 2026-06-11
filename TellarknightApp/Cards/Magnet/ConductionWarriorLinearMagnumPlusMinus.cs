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
            return localStats;
        }
    }
}