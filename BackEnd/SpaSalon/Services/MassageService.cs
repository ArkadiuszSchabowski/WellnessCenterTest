using AutoMapper;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;
using SpaSalon.Models;

namespace SpaSalon.Services
{
    public interface IMassageService
    {
        int CreateMassage(CreateMassageDto dto);
        public List<MassageName> GetAll();
        MassageName GetMassage(int id);
    }
    public class MassageService : IMassageService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public MassageService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateMassage(CreateMassageDto dto)
        {
            if(dto == null)
            {
                throw new BadRequestException("Bad request");
            }
            var massage = _mapper.Map<MassageName>(dto);

            _context.MassageNames.Add(massage);
            _context.SaveChanges();

            return massage.Id;
        }

        public List<MassageName> GetAll()
        {
            if (!_context.MassageNames.Any())
            {
                throw new NotFoundException("Not found");
            }
            return _context.MassageNames.ToList();
        }

        public MassageName GetMassage(int id)
        {
            var massage = _context.MassageNames.FirstOrDefault(m => m.Id == id);

            if(massage == null)
            {
                throw new BadRequestException("Not found");
            }

            return massage;
        }
    }

}
