using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Database.Entities;
using SpaSalon.Models;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            //TODO
            var users = new List<User>();
            return users;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            //TODO
            return Ok();
        }
        [HttpPost("registration")]
        public ActionResult Registration([FromBody] User user)
        {
            //TODO
            return Ok();
        }
    }
}
