using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index(string id)
        {
            return Ok();
        }
    }
}
