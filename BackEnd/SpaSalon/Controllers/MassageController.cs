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
    public class MassageController : ControllerBase
    {
        private readonly IMassageService _service;

        public MassageController(IMassageService service)
        {
            _service = service;
        }
        [HttpGet]
        //All
        public ActionResult<List<MassageName>> GetAll()
        {
            var massages = _service.GetAll();
            return Ok(massages);
        }
        [HttpGet("{id}")]
        //All
        public ActionResult<MassageName> GetMassage([FromRoute] int id)
        {
            MassageName massageName = _service.GetMassage(id);
            return Ok(massageName);
        }
        [HttpPost]
        //Manager
        public ActionResult CreateNewTypeMassage([FromBody] CreateMassageDto dto)
        {
            int id = _service.CreateMassage(dto);
            return Created($"api/massage/{id}", null);
        }
        [HttpDelete("{id}")]
        //Manager
        public ActionResult RemoveMassage([FromRoute] int id)
        {
            _service.RemoveMassage(id);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult UpdateMassage([FromBody] UpdateMassageDto dto, [FromRoute] int id)
        {
            var massage = _service.UpdateMassage(dto, id);
            return Ok(massage);
        }
    }
}
