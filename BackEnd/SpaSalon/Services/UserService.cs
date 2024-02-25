using Microsoft.EntityFrameworkCore;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;

namespace SpaSalon.Services
{
    public interface IUserService
    {
        void RemoveUser(int id);
        public List<User> GetUsers();
    }
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            if (users == null)
            {
                throw new NotFoundException("Not found");
            }
            return users;
        }

        public void RemoveUser(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException("Not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

}
