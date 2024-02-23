using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Models;

namespace SpaSalon.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<RegisterUserDto> _passwordHasher;

        public AccountService(MyDbContext context, IMapper mapper, IPasswordHasher<RegisterUserDto> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {

            var hashedPassword = _passwordHasher.HashPassword(dto, dto.Password);
            dto.Password = hashedPassword;

            var user = _mapper.Map<User>(dto);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

}
