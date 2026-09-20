using Microsoft.AspNetCore.Mvc;
using Practice_A.Models.Authentication;
using Practice_A.Repository;
using Practice_A.Services;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("User")]
        public async Task<IActionResult> GetUserName([FromQuery] String Email)
        {
            // 1. validate the user (User Exists or not)
            try
            {
                if (!new EmailAddressAttribute().IsValid(Email))
                {
                    return BadRequest("Invalid Email format.");
                }

                // 2. If yes --> return login successful, else --> Return Invalid User
                UserDetailsModel user = await _userRepository.GetUserName(Email);
                if (user is null)
                {
                    return NotFound("User not found");
                }
                return Ok(user.name);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Invalid Login Attempt. Exception: {ex.Message}");
                return StatusCode(500,"Error while logging In");
            }

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
