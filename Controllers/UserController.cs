using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetCurrentDateTime")]
        public IActionResult GetDateTime() {
            var obj = new  {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Show/{name}")] 
        public IActionResult Show(string name) {
            var message = $"Hello {name}, welcome!";
            return Ok(new { message });
        }
    }
}