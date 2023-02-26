using BugTracking.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BugTracking.DAL
{
    public class BugTrackingContext : DbContext
    {
        public BugTrackingContext(DbContextOptions<BugTrackingContext> option) : base(option) { }

        //Project Model
        public DbSet<Project> Projects { get; set; } 
        //Bugs Model
        public DbSet<Bug> Bugs { get; set; }
        //Message Model
        public DbSet<Message> Messages { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> userRoles { get; set; }

        //converting table to JSON or vice versa
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bug>().ToTable(nameof(Bug));
            modelBuilder.Entity<Message>().ToTable(nameof(Message));
            modelBuilder.Entity<Project>().ToTable(nameof(Project));
            modelBuilder.Entity<Role>().ToTable(nameof(Role));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<UserRole>()
                .ToTable(nameof(UserRole))
                .HasKey(ur => new { ur.RoleId, ur.UserId });
            }
        }

    }

