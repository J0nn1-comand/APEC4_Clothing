using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Shop.DataModels.Models
{
    public partial class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext()
        {
        }

        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShippingStatus> ShippingStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShoppingDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.ToTable("AdminInfo");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.LastLogin).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(6);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.LastLogin).HasMaxLength(25);

                entity.Property(e => e.MobileNo).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(6);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.OrderId).HasMaxLength(9);

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.ShippingAddress).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.OrderId).HasMaxLength(9);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShippingStatus>(entity =>
            {
                entity.ToTable("ShippingStatus");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
