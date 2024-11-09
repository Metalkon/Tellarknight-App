﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class SuperheavySamuraiMotorbike : Card
    {
        public SuperheavySamuraiMotorbike() 
        {
            Name = "Superheavy Samurai Motorbike";
            Type = "Machine";
            Attribute = "Earth";
            Level = 2;
            Attack = 800;
            Defense = 1200;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "SHS" };
            Id = 83334932;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // SHS Check
            if (deck.Any(x => x is SuperheavySamuraiProdigyWakaushi)
                && (hand.Any(x => x is SuperheavySamuraiSoulgaiaBooster) || deck.Any(x => x is SuperheavySamuraiSoulgaiaBooster))
                && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei))
            {
                localStats.AverageXyzNoTellar = true;
            }

            // Benki + NS Check
            if (deck.Any(x => x is SuperheavySamuraiProdigyWakaushi) && deck.Any(x => x is SuperheavySamuraiMonkBigBenkei)
                && hand.Any(x => x.Level == 4 && x != this))
            {
                localStats.AverageXyzNoTellar = true;
            }

            // Extender Play (NOTE: Update As Needed)
            if (hand.Any(x => x.Role.Contains("Extender") && x.Level == 4 && x is not MathmechCircular)
                || (hand.Any(x => x.Archetype.Contains("Runick") && x.Role == "Extender" && x.Type == "Spell") && extraDeck.Any(x => x is GeriTheRunickFangs)))
            {
                localStats.AverageXyzNoTellar = true;
                return localStats;
            }

            return localStats;
        }
    }
}