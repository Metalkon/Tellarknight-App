using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Cards;
using TellarknightApp.Components.Pages;
using TellarknightApp.Services;

namespace TellarknightApp.Models
{
    public class DisplayValues
    {
        // Basic Stats
        public int DeckSize { get; set; }
        public int TotalMonsters { get; set; }
        public StatRange ComboChance { get; set; }
        public StatRange BrickChance { get; set; }
        public StatRange BrickRate { get; set; }

        // Summon Stats
        public StatRange XyzSummonZero { get; set; }
        public StatRange XyzSummonOne { get; set; }
        public StatRange XyzSummonTwo { get; set; }
        public StatRange PendulumnChance { get; set; }
        public StatRange OracleChance { get; set; }

        // Hand Stats
        public StatRange AverageHandTellars { get; set; }
        public StatRange AverageHandExtenders { get; set; }
        public StatRange AverageHandHT { get; set; }

        // Other Stats
        public StatRange IsoldeBrickChance { get; set; }
        public StatRange ArmoredBrickChance { get; set; }
        public StatRange RyzealLockChance { get; set; }

        public DisplayValues()
        {
            DeckSize = 40;
            TotalMonsters = 0;
            ComboChance = new StatRange();
            BrickChance = new StatRange();
            BrickRate = new StatRange();

            XyzSummonZero = new StatRange();
            XyzSummonOne = new StatRange();
            XyzSummonTwo = new StatRange();
            PendulumnChance = new StatRange();
            OracleChance = new StatRange();

            AverageHandTellars = new StatRange();
            AverageHandExtenders = new StatRange();
            AverageHandHT = new StatRange();

            IsoldeBrickChance = new StatRange();
            ArmoredBrickChance = new StatRange();
            RyzealLockChance = new StatRange();
        }
    }
}

