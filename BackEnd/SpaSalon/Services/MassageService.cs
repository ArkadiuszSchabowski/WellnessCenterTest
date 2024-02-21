using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;

namespace SpaSalon.Services
{
    public interface IMassageService
    {
        public List<MassageName> GetAll();
        MassageName GetMassage(int id);
    }
    public class MassageService : IMassageService
    {
        private readonly MyDbContext _context;

        public MassageService(MyDbContext context)
        {
            _context = context;
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
