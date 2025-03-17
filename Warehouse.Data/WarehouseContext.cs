using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
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
                entity.HasKey(c => c.IDCategory);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(c => c.IDCity);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(o => o.IDOrder);
                
                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.IdUser);
                entity.HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.IdProduct);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(s => s.IDSupplier);
                entity.HasOne(s => s.City)
                    .WithMany(c => c.Suppliers)
                    .HasForeignKey(s => s.IDCity);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.IDUser);
            });
        }

    }
}
