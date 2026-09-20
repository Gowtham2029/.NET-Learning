using Microsoft.AspNetCore.Mvc;
using Practice_A.Models.Authentication;
using Practice_A.Services;

namespace Practice_A.Controllers.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ITestService _service;

        public AuthController(ITestService service)
        {
            _service = service;
        }

        [HttpGet("Test")]
        public IActionResult GetId()
        {
            return Ok(_service.Id);
        }

        [HttpGet("GreetUser")]
        public IActionResult GetGreetMessage(string? userName)
        {
            string GreetMessage = _service.GetGreetMessage(userName);
            return Ok(GreetMessage);
        }

        [HttpGet("{id:int:min(1)}/orders")]
        public IActionResult GetOrderDetails(
            [FromRoute] int id, 
            [FromQuery] int page,
            [FromQuery] int pageSize
         )
        {
            return Ok(new
            {
                OrderId = id,
                pageNum = page,
                pageSize = pageSize
            });

        }

        [HttpPost("SignUp")]
        public IActionResult CreateUser([FromBody] UserRegistrationModel user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            Console.WriteLine("Hello: " + string.Empty);
            return Ok($"New User Created with User name: {user.UserName}");
        }
    }
}
