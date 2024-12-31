using MehmanFoods.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class MehmanFoodsDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchIngredient> BatchIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<BatchNo> BatchesNo { get; set; }

        public DbSet<PaymentStatus> paymentStatuses { get; set; }

        public MehmanFoodsDbContext() : base()
        { }

        public MehmanFoodsDbContext(DbContextOptions<MehmanFoodsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-HF285NV\\SQLEXPRESS01;Database=MehmanFoods;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)       // Order has one Customer
            .WithMany(c => c.Orders)       // Customer has many Orders
            .HasForeignKey(o => o.CustomerId) // Foreign key property in Order
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
            .Property(od => od.TotalPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
            .Property(od => od.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.ProductPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.ProductWholeSalePrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.ProductBuyRatePrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.OpeningStockRate)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Sale>()
            .Property(s => s.TotalAmount)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
            .Property(o => o.SubTotalCost)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
            .Property(o => o.Balance)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
            .Property(o => o.PaidAmount)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SaleProduct>()
            .Property(sp => sp.UnitPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Batch>()
            .Property(b => b.ExpectedProfitPercentage)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Batch>()
            .Property(b => b.ExpectedSales)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BatchIngredient>()
            .Property(b => b.QuantityUsed)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BatchIngredient>()
            .Property(b => b.PriceUsed)
            .HasColumnType("decimal(18,2)");
        }
    }
}
