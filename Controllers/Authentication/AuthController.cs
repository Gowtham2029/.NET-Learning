using Microsoft.AspNetCore.Mvc;
using Practice_A.Models.Authentication;
using Practice_A.Services;
using Practice_A.Repository;

namespace Practice_A.Controllers.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ITestService _service;
        private readonly IUserRepository _userRepository;
        public AuthController(ITestService service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> GetUserName([FromQuery] String Email)
        {
            var userName = await _userRepository.GetUserName(Email);
            return Ok(userName);
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
