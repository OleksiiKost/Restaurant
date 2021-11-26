using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurant
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<ListOfDishesToOrder> ListOfDishesToOrders { get; set; } = null!;
        public virtual DbSet<ListOfOrderToProvider> ListOfOrderToProviders { get; set; } = null!;
        public virtual DbSet<ListOfProviderInvoice> ListOfProviderInvoices { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderToProvider> OrderToProviders { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderInvoice> ProviderInvoices { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KJE50N8;Database=Restaurant;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("PK_Restaurant_IdIngredient");

                entity.Property(e => e.IdIngredient).ValueGeneratedNever();

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.NameIngredient).HasMaxLength(30);

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Ingredients_IdUnitOfMent");
            });

            modelBuilder.Entity<ListOfDishesToOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdDish, e.IdOrder })
                    .HasName("PK_Restaurant_IdDish_IdOrder");

                entity.ToTable("ListOfDishesToOrder");

                entity.Property(e => e.NameDish).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ListOfOrderToProvider>(entity =>
            {
                entity.HasKey(e => new { e.IdOrderToProvider, e.IdIngredient })
                    .HasName("PK_Restaurant_IdOrderToProvider_IdIngredient");

                entity.ToTable("ListOfOrderToProvider");

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.ListOfOrderToProviders)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_ListOfOrderToProvider_IdUnitOfMent");
            });

            modelBuilder.Entity<ListOfProviderInvoice>(entity =>
            {
                entity.HasKey(e => new { e.IdInvoice, e.IdIngredient })
                    .HasName("PK_Restaurant_IdInvoice_IdIngredient");

                entity.ToTable("ListOfProviderInvoice");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.ListOfProviderInvoices)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_ListOfProviderInvoice_IdUnitOfMent");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdDish)
                    .HasName("PK_Restaurant_IdDish");

                entity.ToTable("Menu");

                entity.Property(e => e.IdDish).ValueGeneratedNever();

                entity.Property(e => e.NameDish).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Recipe)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Menu_IdUnitOfMent");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Restaurant_IdOrderh");

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_IdPersonal");
            });

            modelBuilder.Entity<OrderToProvider>(entity =>
            {
                entity.HasKey(e => e.IdOrderToProvider)
                    .HasName("PK_Restaurant_IdOrderToProvider");

                entity.ToTable("OrderToProvider");

                entity.Property(e => e.IdOrderToProvider).ValueGeneratedNever();

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.OrderToProviders)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_OrderToProvider_IdProvider");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal)
                    .HasName("PK_Restaurant_IdPersonal");

                entity.ToTable("Personal");

                entity.HasIndex(e => e.PhoneNumber, "Restaurant_Personal_PhoneNumber_Unique")
                    .IsUnique();

                entity.Property(e => e.IdPersonal).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(30);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Position).HasMaxLength(40);

                entity.Property(e => e.Shift).HasMaxLength(30);

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK_Restaurant_IdProvider");

                entity.ToTable("Provider");

                entity.Property(e => e.IdProvider).ValueGeneratedNever();

                entity.Property(e => e.AdressProvider).HasMaxLength(150);

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .HasColumnName("EMail")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProviderInvoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice)
                    .HasName("PK_Restaurant_IdInvoice");

                entity.ToTable("ProviderInvoice");

                entity.Property(e => e.IdInvoice).ValueGeneratedNever();

                entity.Property(e => e.DateDelivery).HasColumnType("datetime");

                entity.Property(e => e.DateOfIssueInvoice).HasColumnType("datetime");

                entity.HasOne(d => d.IdOrderToProviderNavigation)
                    .WithMany(p => p.ProviderInvoices)
                    .HasForeignKey(d => d.IdOrderToProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_ProviderInvoice_IdOrderToProvider");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.ProviderInvoices)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_ProviderInvoice_IdProvider");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => new { e.IdIngredient, e.IdDish })
                    .HasName("PK_Restaurant_IdIngredient_IdDish");

                entity.Property(e => e.MethodOfCooking).HasMaxLength(200);

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Recipes_IdUnitOfMent");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant)
                    .HasName("PK_Restaurant_IdRestaurant");

                entity.ToTable("RESTAURANT");

                entity.Property(e => e.IdRestaurant).ValueGeneratedNever();

                entity.Property(e => e.AdressRestaurant).HasMaxLength(150);

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .HasColumnName("EMail")
                    .IsFixedLength();

                entity.Property(e => e.FullNameOwner).HasMaxLength(120);

                entity.Property(e => e.NameRestaurant).HasMaxLength(50);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => new { e.IdIngredient, e.IdRestaurant, e.DateOfManufacture })
                    .HasName("PK_Restaurant_IdIngredient_IdRestaurant_DateOfManufacture");

                entity.ToTable("Storage");

                entity.Property(e => e.DateOfManufacture).HasColumnType("datetime");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Storage_IdInvoice");

                entity.HasOne(d => d.IdUnitOfMentNavigation)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.IdUnitOfMent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Storage_IdUnitOfMent");
            });

            modelBuilder.Entity<UnitOfMeasurement>(entity =>
            {
                entity.HasKey(e => e.IdUnitOfMent)
                    .HasName("PK_Restaurant_IdUnitOfMent");

                entity.ToTable("UnitOfMeasurement");

                entity.Property(e => e.IdUnitOfMent).ValueGeneratedNever();

                entity.Property(e => e.NameUnit).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
