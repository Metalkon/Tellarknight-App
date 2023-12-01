using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    internal class DeckStatistics
    {
        public float BrickChance { get; set; }
        public float AverageTellars { get; set; }
        public float AverageXyzNoTellar { get; set; }
        public float AverageXyzWithTellar { get; set; }
        public float AverageXyzUnukOrLyran { get; set; }
        public float AverageXyzTwoTellars { get; set; }
        public float ZefraathAndSHS { get; set; }
        public float ZefraathAndThuban { get; set; }
        public float ZefraComboWithTrap { get; set; }
        public float ZefraComboWithNormalAvailable { get; set; }
        public float AverageHandTraps { get; set; }
        public float IsoldeBrick { get; set; }
        public float IsoldeBrickFull { get; set; }

    }
}
