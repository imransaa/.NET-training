using assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace assignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasOne(e => e.Creator)
                .WithMany(e => e.Documents)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Group>()
                .HasOne(e => e.Creator)
                .WithMany(e => e.CreatedGroups)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
