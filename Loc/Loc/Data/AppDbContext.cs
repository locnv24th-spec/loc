using Loc.Models;
using Microsoft.EntityFrameworkCore;

namespace Loc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                      .HasColumnType("TEXT");

                entity.Property(e => e.FullName)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Message)
                      .IsRequired();
            });
        }
    }
}

