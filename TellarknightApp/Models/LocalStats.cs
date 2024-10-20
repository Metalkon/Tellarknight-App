﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class LocalStats
    {
        public bool BrickChance { get; set; } = false;
        public bool AverageTellars { get; set; } = false;
        public bool AverageXyzNoTellar { get; set; } = false;
        public bool AverageXyzOneTellar { get; set; } = false;
        public bool AverageXyzTwoTellar { get; set; } = false;
        public bool PendulumSummon { get; set; } = false;
        public bool OracleCombo { get; set; } = false;
        public bool ZefraathAndThuban { get; set; } = false;
        public bool ZefraComboWithTrap { get; set; } = false;
        public bool ZefraComboWithNormalAvailable { get; set; } = false;
        public bool AverageHandTraps { get; set; } = false;
        public bool AverageBystials { get; set; } = false;
        public bool IsoldeBrick { get; set; } = false;
    }
}
