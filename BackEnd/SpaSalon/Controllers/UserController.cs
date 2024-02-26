using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedAccessException("Unauthorized access!");
            }

            _service.RemoveUser(id);
            return Ok();
        }
    }
}
