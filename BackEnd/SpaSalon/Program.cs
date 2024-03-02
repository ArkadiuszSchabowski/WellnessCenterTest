using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using SpaSalon.Database;
using SpaSalon.Database.Entities;
//using SpaSalon.Middleware;
using SpaSalon.Seeders;
using SpaSalon.Services;
using System.Text;
using System.Text.Json.Serialization;

namespace SpaSalon
{
    public class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var authenticationSettings = new AuthenticationSettings();

            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
            builder.Logging.AddNLog();
            builder.Services.AddSingleton(authenticationSettings);
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });


            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SpaSalonConnectionString")));
            builder.Services.AddScoped<IMassageService, MassageService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IAccountSeeder, AccountSeeder>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<IRegisterAdminService, AccountService>();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:5173")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
            );
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Salon Spa - API");
            });
            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
