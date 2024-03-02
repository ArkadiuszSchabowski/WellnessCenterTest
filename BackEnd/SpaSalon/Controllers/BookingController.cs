using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Models;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult BookingMassage(BookingMassageDto dto)
        {
            int id = _service.CreateBooking(dto);
            return Created("/api/booking/id", null);
        }

        [Authorize(Roles = "Manager, Admin")]
        [HttpGet("{id}")]
        public ActionResult GetBooking(int id)
        {
            var booking = _service.GetBooking(id);
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveBooking(int id)
        {
            _service.RemoveBooking(id);
            return NoContent();
        }
    }
}
