using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
           
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }

        // /api/values2/divide/1/2
        [HttpGet("{Numerator}/{Denominator}")]
        public IActionResult Divide(double Numerator, double Denominator)
        {
            Console.WriteLine("Hello world");

            if (Denominator == 0)
            {
                return BadRequest();
            }

            return Ok(Numerator / Denominator);
        }

        // /api/values2 /squareroot/4
        [HttpGet("{radicand}")]
        public IActionResult Squareroot(double radicand)
        {
            Console.WriteLine("Hello world");

            if (radicand < 0)
            {
                return BadRequest();
            }

            return Ok(Math.Sqrt(radicand));
        }
    }
}
