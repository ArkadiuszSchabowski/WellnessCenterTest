using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Database.Entities;
using SpaSalon.Models;
using SpaSalon.Services;
using System.Reflection.Metadata.Ecma335;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MassageController : ControllerBase
    {
        private readonly IMassageService _service;

        public MassageController(IMassageService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<MassageName>> GetAll()
        {
            var massages = _service.GetAll();
            return Ok(massages);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<MassageName> GetMassage([FromRoute] int id)
        {
            MassageName massageName = _service.GetMassage(id);
            return Ok(massageName);
        }

        [HttpPost]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult CreateNewTypeMassage([FromBody] CreateMassageDto dto)
        {
            int id = _service.CreateMassage(dto);
            return Created($"api/massage/{id}", null);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult UpdateMassage([FromBody] UpdateMassageDto dto, [FromRoute] int id)
        {
            var massage = _service.UpdateMassage(dto, id);
            return Ok(massage);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult RemoveMassage([FromRoute] int id)
        {
            _service.RemoveMassage(id);
            return NoContent();
        }
        [HttpPost("booking")]
        public ActionResult BookingMassage(BookingMassageDto dto)
        {
            var massage = _service.BookingMassage(dto);
            return Created();
        }
    }
}
