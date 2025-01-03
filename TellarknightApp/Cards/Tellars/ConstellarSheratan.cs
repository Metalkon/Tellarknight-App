﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ConstellarSheratan : Card
    {
        public ConstellarSheratan()
        {
            Name = "Constellar Sheratan";
            Type = "Beast";
            Attribute = "Light";
            Level = 3;
            Attack = 700;
            Defense = 1900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Id = 78486968;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {            
            // Sheratan + Tellar (No Twinkle)
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Constellar") || x.Archetype.Contains("Tellarknight")))
                && deck.Any(x => x is ConstellarCaduceus)
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights)))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Sheratan + Twinkle (One Card Combo)
            if ((hand.Any(x => x is ConstellarTwinkle) || deck.Any(x => x is ConstellarTwinkle))
                && (hand.Any(x => x is ConstellarCaduceus) || deck.Any(x => x is ConstellarCaduceus)))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Sheratan + Pollux/Algiedi -> Caduceus
            if ((hand.Any(x => x is ConstellarPollux) || hand.Any(x => x is ConstellarAlgiedi) || hand.Any(x => x.Role == "Extender" && x.Level == 4))
                && (hand.Any(x => x is ConstellarCaduceus) || deck.Any(x => x is ConstellarCaduceus)))
            {
                localStats.AverageXyzTwoTellar = true;
                return localStats;
            }

            // Sheratan + Extender -> Caduceus
            if (hand.Any(x => x.Role == "Extender" && x.Level == 4)
                && hand.Any(x => x is not ConstellarCaduceus)
                && deck.Any(x => x is ConstellarCaduceus))
            {
                Random random = new Random();
                if (random.Next(1, 9) <= 7)
                {
                    localStats.AverageXyzOneTellar = true;
                }
            }

            return localStats;
        }
    }
}