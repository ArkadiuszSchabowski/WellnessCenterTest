﻿using Microsoft.EntityFrameworkCore;

namespace SpaSalon.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
