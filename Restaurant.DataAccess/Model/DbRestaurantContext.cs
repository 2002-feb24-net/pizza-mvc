using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Restaurant.DataAccess.Model
{
    public partial class DbRestaurantContext : DbContext
    {
        public DbRestaurantContext()
        {
        }

        public DbRestaurantContext(DbContextOptions<DbRestaurantContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            config.AddUserSecrets<DbRestaurantContext>();
            var Configuration = config.Build();
            string conn = Configuration["ConnectionStrings:DbRestaurantContext"];
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventorys> Inventorys { get; set; }
        public virtual DbSet<Orderlines> Orderlines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B802CFB926");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ_Customer_Username")
                    .IsUnique();

                entity.HasIndex(e => new { e.Username, e.Password })
                    .HasName("UQ_Customers")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventorys>(entity =>
            {
                entity.HasKey(e => e.InventoryId);

                entity.HasIndex(e => new { e.ProductId, e.StoreId })
                    .HasName("UQ_INVENTORYS")
                    .IsUnique();

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventorys)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTS_PRODUCTID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorys)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_STORES_STOREID");
            });

            modelBuilder.Entity<Orderlines>(entity =>
            {
                entity.HasKey(e => e.OrderlineId)
                    .HasName("PK__Orderlin__F8912DD240F319D2");

                entity.Property(e => e.OrderlineId).HasColumnName("OrderlineID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OL_ORDERS_ORDERID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OL_PRODUCTS_PRODUCTID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF185349FE");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TimeOrdered).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMERS_CUSTOMERID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STORE_STOREID");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6ED04F3FF45");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Stores__3B82F0E1FB793EE3");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.StreetAddress).HasMaxLength(50);

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
