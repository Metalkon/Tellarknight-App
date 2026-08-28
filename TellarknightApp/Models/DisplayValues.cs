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
        // Statistics
        public int Count { get; set; }

        // Basic Stats
        public int DeckSize { get; set; }
        public int TotalMonsters { get; set; }
        public double ComboChance { get; set; }
        public double BrickChance { get; set; }
        public double BrickRate { get; set; }

        // Summon Stats
        public double XyzSummonZero { get; set; }
        public double XyzSummonOne { get; set; }
        public double XyzSummonTwo { get; set; }
        public double PendulumnChance { get; set; }
        public double OracleChance { get; set; }

        // Hand Stats
        public double AverageHandTellars { get; set; }
        public double AverageHandExtenders { get; set; }
        public double AverageHandHT { get; set; }

        // Other Stats
        public double IsoldeBrickChance { get; set; }
        public double ArmoredBrickChance { get; set; }
        public double RyzealLockChance { get; set; }

        public DisplayValues()
        {
            DeckSize = 40;
            TotalMonsters = 0;
            ComboChance = 0;
            BrickChance = 0;
            BrickRate = 0;

            XyzSummonZero = 0;
            XyzSummonOne = 0;
            XyzSummonTwo = 0;
            PendulumnChance = 0;
            OracleChance = 0;

            AverageHandTellars = 0;
            AverageHandExtenders = 0;
            AverageHandHT = 0;

            IsoldeBrickChance = 0;
            ArmoredBrickChance = 0;
            RyzealLockChance = 0;
        }

        public double this[VarianceStat stat] => stat switch
        {
            VarianceStat.ComboChance => ComboChance,
            VarianceStat.BrickChance => BrickChance,
            VarianceStat.BrickRate => BrickRate,
            VarianceStat.XyzSummonZero => XyzSummonZero,
            VarianceStat.XyzSummonOne => XyzSummonOne,
            VarianceStat.XyzSummonTwo => XyzSummonTwo,
            VarianceStat.PendulumnChance => PendulumnChance,
            VarianceStat.OracleChance => OracleChance,
            VarianceStat.AverageHandTellars => AverageHandTellars,
            VarianceStat.AverageHandExtenders => AverageHandExtenders,
            VarianceStat.AverageHandHT => AverageHandHT,
            VarianceStat.RyzealLockChance => RyzealLockChance,
            _ => throw new ArgumentOutOfRangeException(nameof(stat))
        };
    }

    public enum VarianceStat
    {
        ComboChance,
        BrickChance,
        BrickRate,
        XyzSummonZero,
        XyzSummonOne,
        XyzSummonTwo,
        PendulumnChance,
        OracleChance,
        AverageHandTellars,
        AverageHandExtenders,
        AverageHandHT,
        RyzealLockChance
    }
}

