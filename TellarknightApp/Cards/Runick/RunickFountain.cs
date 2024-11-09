﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class RunickFountain : Card
    {
        public RunickFountain()
        {
            Name = "Runick Fountain";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Runick" };
            Id = 92107604;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}