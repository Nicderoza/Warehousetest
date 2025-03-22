using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Models;

namespace Warehouse.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(c => c.CategoryID);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(c => c.CityID);
                entity.HasMany(c => c.Suppliers)  // Una città ha molti fornitori
              .WithOne(s => s.City)      // Un fornitore appartiene a una città
              .HasForeignKey(s => s.CityID)  // La chiave esterna è CityID in Suppliers
              .OnDelete(DeleteBehavior.Restrict);  // Impedisce la cancellazione della città se ci sono fornitori
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(o => o.OrderID);

                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserID);
                entity.HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.ProductID);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(s => s.SupplierID);
                entity.HasOne(s => s.City)
                    .WithMany(c => c.Suppliers)
                    .HasForeignKey(s => s.CityID);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.UserID);
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(p => p.ProductID);

                // Relazione con la categoria
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryID)
                    .OnDelete(DeleteBehavior.Restrict); // Evita eliminazioni a cascata

                // Relazione con il fornitore
                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relazione con gli ordini
                entity.HasMany(p => p.Orders)
                    .WithOne(o => o.Product)
                    .HasForeignKey(o => o.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
