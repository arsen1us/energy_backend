using energy_backend;
using energy_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace energy_backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        EnergyContext _database;

        public UserController(EnergyContext database)
        {
            _database = database;
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
    }
}
