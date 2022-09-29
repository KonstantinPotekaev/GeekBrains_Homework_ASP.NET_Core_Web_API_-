using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WeatherForeCast.Models;

namespace WeatherForeCast.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherForeCastController : ControllerBase
    {
        private readonly WeatherForeCastHolder _holder;

        public WeatherForeCastController(WeatherForeCastHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("add")]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] double temp)
        {
            _holder.Add(date, temp);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            
            return Ok(_holder.Delete(date));
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] double temp)
        {
            
            return Ok(_holder.Update(date, temp));
        }


        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            return Ok(_holder.Get(dateFrom, dateTo));
        }
    }
}
