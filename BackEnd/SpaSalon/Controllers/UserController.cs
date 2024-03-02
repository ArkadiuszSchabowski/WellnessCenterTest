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
            if (User?.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedAccessException("Unauthorized access!");
            }

            _service.RemoveUser(id);
            return Ok();
        }
        [HttpGet("role")]
        public ActionResult GetRoles()
        {
            var roles = _service.GetRoles();
            return Ok(roles);
        }
        [HttpPatch("{dto.UserId}/role/{dto.RoleId}")]
        public ActionResult UpdateRole([FromRoute] UpdateRoleDto dto)
        {
            _service.UpdateRole(dto);
            return Ok($"User id: {dto.UserId} changed role {dto.RoleId}");
        }
    }
}
