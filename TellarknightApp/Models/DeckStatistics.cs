using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    internal class DeckStatistics
    {
        public float BrickChance { get; set; } = 0;
        public float AverageTellars { get; set; } = 0;
        public float AverageXyzNoTellar { get; set; } = 0;
        public float AverageXyzWithTellar { get; set; } = 0;
        public float AverageXyzSpellOrAltairan { get; set; } = 0;
        public float AverageXyzTwoTellars { get; set; } = 0;
        public float AverageXyzUnknown { get; set; } = 0;
        public float PendulumnSummon { get; set; } = 0;
        public float ZefraathAndSHS { get; set; } = 0;
        public float ZefraathAndThuban { get; set; } = 0;
        public float ZefraComboWithTrap { get; set; } = 0;
        public float ZefraComboWithNormalAvailable { get; set; } = 0;
        public float AverageHandTraps { get; set; } = 0;
        public float IsoldeBrick { get; set; } = 0;
    }
}
