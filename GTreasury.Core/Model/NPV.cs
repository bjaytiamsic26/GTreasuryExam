using System;
using System.Collections.Generic;
using System.Linq;

namespace GTreasury.Core.Model
{
    public class NPV 
    {
        public double LowerBoundDR { get; set; }
        public double UpperBoundDR { get; set;  }
        public double  DiscountRateIncrement { get; set; }
        public double CashFlow { get; set; }
        public double TimeIncrement {
            get { return (UpperBoundDR - (LowerBoundDR - 1)) / DiscountRateIncrement; }
          
        }
        public Dictionary<int, double> NpvList = new();

    }
}
