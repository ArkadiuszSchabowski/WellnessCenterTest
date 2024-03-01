using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Models;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll([FromQuery] PaginationInfoDto dto)
        {
            var users = _service.GetUsers(dto);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {

            _service.RemoveUser(id);
            return Ok();
        }
        [HttpGet("role")]
        public ActionResult GetRoles()
        {
            var roles = _service.GetRoles();
            return Ok(roles);
        }
        [HttpPatch("role/{id}")]
        public ActionResult UpdateRole([FromRoute] int id, [FromBody] string role)
        {
            _service.UpdateRole(id, role);
            return Ok($"User id: {id} has role: {role} now");
        }
    }
}
