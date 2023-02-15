using BugTracking.Models;
using Microsoft.EntityFrameworkCore;

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

        //converting table to JSON or vice versa
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bug>().ToTable(nameof(Bug));
            modelBuilder.Entity<Message>().ToTable(nameof(Message));
            modelBuilder.Entity<Project>().ToTable(nameof(Project));
        }

    }
}
