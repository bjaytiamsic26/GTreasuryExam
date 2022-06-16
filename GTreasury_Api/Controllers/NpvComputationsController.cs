using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTreasury.Core.Interface;
using GTreasury.Core.Logic;
using GTreasury.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GTreasury_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class NpvComputationsController : ControllerBase
    {
        private ICalculate CalculateNpv= new Calculate();

        [HttpGet]
        public IActionResult Get(string input)
        {
            var npvModel = JsonConvert.DeserializeObject<NPV>(input);
            if(input == null)
            {
                return BadRequest();
            }

            CalculateNpv.CollectCashflow(npvModel);
            CalculateNpv.TotalNpv(npvModel.NpvList);

            var result = JsonConvert.SerializeObject(npvModel);

            return Ok(result);
        }

    }
}
