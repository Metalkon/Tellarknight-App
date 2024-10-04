using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarCaduceus : Card
    {
        public ConstellarCaduceus() 
        {
            Name = "Constellar Caduceus";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 1550;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Image = "./CardArt/Caduceus.png";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            // Caduceus + Lv4 Constellar
            if (hand.Any(x => x is not ConstellarCaduceus && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellars = true;
            }

            // Caduceus + Lv4 Tellarknight (Spell Search)
            if (hand.Any(x => x is not ConstellarCaduceus && x.Level == 4 && x.Archetype.Contains("Tellarknight")) 
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights)))
            {
                localStats.AverageXyzTwoTellars = true;
            }

            return localStats;
        }
    }
}