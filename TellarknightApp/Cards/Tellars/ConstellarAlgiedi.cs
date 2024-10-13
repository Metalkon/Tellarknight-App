using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarAlgiedi : Card
    {
        public ConstellarAlgiedi()
        {
            Name = "Constellar Algiedi";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 1400;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Image = "./CardArt/Algiedi.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            // Algiedi + Any Lv4 Constellar
            if (hand.Any(x => x != this && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}