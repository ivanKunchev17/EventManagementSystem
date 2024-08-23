using EventManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence
{
    public class EventManagementSystemContext : DbContext
    {
        public EventManagementSystemContext()
        {
            
        }

        public EventManagementSystemContext(DbContextOptions<EventManagementSystemContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NKUNCHEVPC;Initial Catalog=EventManagementSystemDB;Integrated Security=true; Encrypt=False; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u=>u.Registrations)
                .WithOne(re=>re.User)
                .HasForeignKey(r=>r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Registrations)
                .WithOne(re => re.Event)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.Events)
                .WithOne(re => re.Speaker)
                .HasForeignKey(r => r.SpeakerId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }


        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
