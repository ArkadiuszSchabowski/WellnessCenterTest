using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;
using SpaSalon.Models;

namespace SpaSalon.Services
{
    public interface IUserService
    {
        void RemoveUser(int id);
        public List<UserDto> GetUsers(PaginationInfoDto dto);
        void UpdateRole(UpdateRoleDto dto);
        List<Role> GetRoles();
        object GetUser(int id);
    }
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(MyDbContext context, ILogger<UserService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public List<UserDto> GetUsers(PaginationInfoDto dto)
        {
            var users = _context.Users.Include(u => u.Role).Skip(dto.PageSize * (dto.PageNumber -1)).Take(dto.PageSize).ToList();
            
            if (users == null)
            {
                throw new NotFoundException("User not found");
            }
            List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        public object GetUser(int id)
        {
            var user = GetUserById(id);

            return user;
        }

        public void RemoveUser(int id)
        {
            var user = GetUserById(id);

            _logger.LogWarning($"Remove user {id}");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void UpdateRole(UpdateRoleDto dto)
        {
            var user = GetUserById(dto.UserId);

            GetRoleById(dto.RoleId);

            _mapper.Map(dto, user);
            _context.SaveChanges();
        }

        private void GetRoleById(int roleId)
        {
            var targetRole = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            if (targetRole == null)
            {
                throw new NotFoundException($"Role with Id: {roleId} not found");
            }
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new NotFoundException("Not found");
            }
            return user;
        }
    }

}
