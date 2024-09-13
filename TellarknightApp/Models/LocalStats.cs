using System;
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
        public bool AverageExtenders { get; set; } = false;
        public bool AverageXyzNoTellar { get; set; } = false;
        public bool AverageXyzWithTellar { get; set; } = false;
        public bool AverageXyzSpellOrAltairan { get; set; } = false;
        public bool AverageXyzTwoTellars { get; set; } = false;
        public bool ZefraathAndSHS { get; set; } = false;
        public bool ZefraathAndThuban { get; set; } = false;
        public bool ZefraComboWithTrap { get; set; } = false;
        public bool ZefraComboWithNormalAvailable { get; set; } = false;
        public bool AverageHandTraps { get; set; } = false;
        public bool IsoldeBrick { get; set; } = false;
        public bool PendulumnSummon { get; set; } = false;
        public bool AverageXyzUnknown { get; set; } = false;
    }
}
