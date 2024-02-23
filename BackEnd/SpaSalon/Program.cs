using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
using SpaSalon.Models;
using SpaSalon.Services;

namespace SpaSalon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SpaSalonConnectionString")));
            builder.Services.AddScoped<IMassageService, MassageService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IPasswordHasher<RegisterUserDto>, PasswordHasher<RegisterUserDto>>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
