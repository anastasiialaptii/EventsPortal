using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EventsPortalDbContext
{
    public class EventsPortalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventUser> EventUsers { get; set; }

        public EventsPortalDbContext(DbContextOptions<EventsPortalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUser>()
                .HasKey(eu => new { eu.UserId, eu.EventId });
            modelBuilder.Entity<EventUser>()
                .HasOne(e => e.Event)
                .WithMany(eu => eu.EventUser)
                .HasForeignKey(e => e.EventId); 
            modelBuilder.Entity<EventUser>()
                .HasOne(u => u.User)
                .WithMany(eu => eu.EventUser)
                .HasForeignKey(u => u.UserId);
        }
    }
}
