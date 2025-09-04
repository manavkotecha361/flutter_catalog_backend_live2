// using Microsoft.EntityFrameworkCore;
// using MyCatalogApi.webapi.Models;

// namespace MyCatalogApi.webapi.Data;
// public class AppDbContext : DbContext
// {
//     public DbSet<Category> Categories { get; set; }
//     public DbSet<Widget> Widgets { get; set; }

//     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Category>(entity =>
//         {
//             entity.HasKey(c => c.Id);
//         });

//         modelBuilder.Entity<Widget>(entity =>
//         {
//             entity.HasKey(w => w.Id);
//             entity.HasOne(w => w.Category)
//                   .WithMany()
//                   .HasForeignKey(w => w.CategoryId)
//                   .OnDelete(DeleteBehavior.Cascade);
//         });
//     }
// }

using Microsoft.EntityFrameworkCore;
using MyCatalogApi.webapi.Models;

namespace MyCatalogApi.webapi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Widget> Widgets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
        });

        modelBuilder.Entity<Widget>(entity =>
        {
            entity.HasKey(w => w.Id);
            entity.HasOne(w => w.Category)
                  .WithMany()
                  .HasForeignKey(w => w.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
