using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTreasury.Core.Model;

namespace GTreasury.Core.Interface
{
    public interface ICalculate
    {
         Task<double> TotalNpv(Dictionary<int, double> NpvList);
        Task<NPV> CollectCashflow(NPV input);
    }
}
