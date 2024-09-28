﻿using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class SatellarknightSirius : Card
    {
        public SatellarknightSirius() 
        {
            Name = "Satellarknight Sirius";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Tellarknight" };
            Image = "./CardArt/Sirius.png";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> onField, List<Card> scales, List<Card> extraDeck, bool normalSummoned)
        {
            CardHelper helper = new CardHelper();

            return localStats;
        }
    }
}