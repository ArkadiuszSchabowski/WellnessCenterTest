using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;
using SpaSalon.Models;

namespace SpaSalon.Services
{
    public interface IBookingService
    {
        int CreateBooking(BookingMassageDto dto);
        Booking GetBooking(int id);
        void RemoveBooking(int id);
    }
    public class BookingService : IBookingService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int CreateBooking(BookingMassageDto dto)
        {
            //TODO - if booking date is taken
            if (dto == null)
            {
                throw new BadRequestException("Bad request");
            }
            var booking = _mapper.Map<Booking>(dto);
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking.Id;
        }

        public Booking GetBooking(int id)
        {
            var booking = GetBookingById(id);

            return booking;
        }

        public void RemoveBooking(int id)
        {
            var booking = GetBookingById(id);

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
        public Booking GetBookingById(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                throw new NotFoundException("Booking not Found");
            }
            return booking;
        }
    }

}
