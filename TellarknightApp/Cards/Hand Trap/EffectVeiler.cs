using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class EffectVeiler : Card
    {
        public EffectVeiler()
        {
            Name = "Effect Veiler";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 1;
            Attack = 0;
            Defense = 0;
            Scale = null;
            Role = "Hand Trap";
            Archetype = new List<string> { "None" };
            Id = 97268402;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}