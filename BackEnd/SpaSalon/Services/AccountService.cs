using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Exceptions;
using SpaSalon.Models;
using System.Security.Claims;

namespace SpaSalon.Services
{
    public interface IAccountService
    {
        void GenerateJWT(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
        void RemoveUser(int id);
        public List<User> GetUsers();
    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(MyDbContext context, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public void GenerateJWT(LoginDto dto)
        {
            var user = _context.Users
                .Include(u =>u.Role)
                .FirstOrDefault(u => u.Login == dto.Login);

            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
        }


        public void RegisterUser(RegisterUserDto dto)
        {
            dto.RoleId = 1;
            var user = _mapper.Map<User>(dto);

            var hashedPassword = _passwordHasher.HashPassword(user, user.HashPassword);
            user.HashPassword = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            if(users == null)
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
