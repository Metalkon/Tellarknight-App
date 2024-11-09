﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MathmechEquation : Card
    {
        public MathmechEquation()
        {
            Name = "Mathmech Equation";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "Mathmech" };
            Id = 14025912;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}