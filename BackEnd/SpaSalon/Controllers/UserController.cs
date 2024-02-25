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
                _service.RemoveUser(id);
                return Ok();
            }
        }
}
