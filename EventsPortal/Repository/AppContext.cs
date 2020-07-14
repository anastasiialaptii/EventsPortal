﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RoleMap(modelBuilder.Entity<Role>());
        }
    }
}
