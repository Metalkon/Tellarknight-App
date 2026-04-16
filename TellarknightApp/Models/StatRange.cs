using System;
using System.Collections.Generic;
using System.Text;

namespace TellarknightApp.Models
{
    public class StatRange
    {
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public StatRange()
        {
            Value = 0;
            Min = 0;
            Max = 0;
        }
    }
}
