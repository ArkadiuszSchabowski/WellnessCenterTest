using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaSalon.Models;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            int id = _service.BookingMassage(dto);
            return Created("/api/booking/id", null);
        }
        [Authorize(Roles = "Manager, Admin")]
        [HttpDelete("{id}")]
        public ActionResult RemoveBooking(int id)
        {
            _service.RemoveBooking(id);
            return NoContent();
        }
    }
}
