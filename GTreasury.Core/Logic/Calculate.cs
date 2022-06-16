using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTreasury.Core.Interface;
using GTreasury.Core.Model;

namespace GTreasury.Core.Logic
{
    public class Calculate: ICalculate
    {
      

        private async Task<double> getNPV(double cF, double dR, double tI)
        {
            var divisor = Math.Pow((1 + (dR/100)), tI);
            return RoundUpNpv(cF / divisor);
        }

        public  async Task<double> TotalNpv(Dictionary<int, double> NpvList)
        {
            var totalNpv = NpvList.Sum(x => x.Value); ;
            return RoundUpNpv(totalNpv);
        }

        public async Task<NPV> CollectCashflow(NPV input)
        {
            var discountRate = input.LowerBoundDR;
            for (int i = 0; i <= input.TimeIncrement; i++)
            {
                input.NpvList.Add(i, await getNPV(input.CashFlow, discountRate, i));
                discountRate += input.DiscountRateIncrement;
            }


            return input;
        
        }

        private double RoundUpNpv(double num)
        {
            return Convert.ToDouble(Math.Round(Convert.ToDecimal(num),2));
        }
    }
}
