using Microsoft.EntityFrameworkCore;
using SpaSalon.Database.Entities;

namespace SpaSalon.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MassageName> MassageNames { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MassageName>().HasData(new MassageName
            {
                Id = 1,
                ServiceName = "Chocolate Massage",
                ServiceTime = 60,
                Description = "Chocolate Massage - Description",
                Price = 199,
                Performer = Enums.PerformerType.Women,
            },
            new MassageName
            {
                Id = 2,
                ServiceName = "Honey Massage",
                ServiceTime = 45,
                Description = "Honey Massage Description",
                Price = 119,
            },
            new MassageName
            {
                Id = 3,
                ServiceName = "Classic Massage",
                ServiceTime = 60,
                Description = "Clasic Massage Description",
                Price = 99,
                Performer = Enums.PerformerType.Man,
            });
        }
    }
}
