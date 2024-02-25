using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            _logger.LogInformation("Test GetAll");
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {
            _logger.LogWarning($"Remove user {id}");
            _service.RemoveUser(id);
            return Ok();
        }
    }
}
