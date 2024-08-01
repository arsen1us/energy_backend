using energy_backend;
using energy_backend.Models;
using energy_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace energy_backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        EnergyContext _database;
        IUserService _userService;

        public UserController(EnergyContext database, IUserService userService)
        {
            _database = database;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrationModel user)
        {
            string jsonUser = JsonSerializer.Serialize(user);
            return Json(jsonUser);
        }

        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel regUser)
        {
            if (regUser is null)
            {
                string errorMessage = "Ошибка регистрации. Объект UserRegistrationModel равно null";
                string jsonErrorMessage = JsonSerializer.Serialize(regUser);
                return BadRequest(jsonErrorMessage);
            }

            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Login = regUser.UserName,
                Password = regUser.Password
            };

            await _userService.AddUser(user);
            return Ok();
        }

        [HttpPost("check-email")]
        public async Task<IActionResult> CheckLoginAvailability([FromBody] CheckUserNameModel user)
        {
            if(await _database.Users.AnyAsync(u => u.Login == user.UserName))
            {
                string message = "This login is using";
                string jsonMessage = JsonSerializer.Serialize(message);
                return Json(jsonMessage);
            }
            else
            {
                string message = "This login isn't using!";
                string jsonMessage = JsonSerializer.Serialize(message);
                return Json(jsonMessage);
            }
        }

        [HttpPost("check-password")]
        public async Task<IActionResult> CheckPassword([FromBody] CheckUserPassword password)
        {
            if(password.Password.Length < 8)
            {
                string message = "This password is too short";
                string jsonMessage = JsonSerializer.Serialize(message);
                return Json(jsonMessage);
            }
            else if(password.Password == "12345678")
            {
                string message = "This password is too easy";
                string jsonMessage = JsonSerializer.Serialize(message);
                return Json(jsonMessage);
            }
            else
            {
                string message = "This password is nice";
                string jsonMessage = JsonSerializer.Serialize(message);
                return Json(jsonMessage);
            }
        }
    }
}
