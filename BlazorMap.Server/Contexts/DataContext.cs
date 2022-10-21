using BlazorMap.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMap.Server.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Marker> Markers => Set<Marker>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marker>()
                        .HasOne(m => m.Category)
                        .WithMany(c => c.Marker)
                        .HasForeignKey(m => m.CategoryId)
                        .OnDelete(DeleteBehavior.SetNull);
        }
    }

}