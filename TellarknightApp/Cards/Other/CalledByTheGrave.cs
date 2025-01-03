﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class CalledByTheGrave : Card
    {
        public CalledByTheGrave() 
        {
            Name = "Called by the Grave";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 24224830;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}