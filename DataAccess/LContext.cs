using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Models;

namespace DataAccess
{
    public partial class LContext : DbContext
    {
        public LContext()
        {
        }

        public LContext(DbContextOptions<LContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<GoodFilterValue> GoodFilterValues { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderContent> OrderContents { get; set; } = null!;

        //Server=DESKTOP-OKU7E5D;Database=L;Integrated Security=True
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategotyId)
                    .HasName("PK__Kategori__EB93B733B73DB27B");

                entity.Property(e => e.CategotyId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoty_id");

                entity.Property(e => e.CategotyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoty_name");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.ParentCategory).HasColumnName("parent_category");

                entity.HasOne(d => d.ParentCategoryNavigation)
                    .WithMany(p => p.InverseParentCategoryNavigation)
                    .HasForeignKey(d => d.ParentCategory)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telephone_number");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.Property(e => e.FilterId)
                    .ValueGeneratedNever()
                    .HasColumnName("filter_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Filters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filters_Categories");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.GoodId)
                    .ValueGeneratedNever()
                    .HasColumnName("good_id");

                entity.Property(e => e.AmountOnStock).HasColumnName("amount_on_stock");

                entity.Property(e => e.CategotyId).HasColumnName("categoty_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Categoty)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.CategotyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tovary__id_kateg__3F466844");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tovary__id_proiz__403A8C7D");
            });

            modelBuilder.Entity<GoodFilterValue>(entity =>
            {
                entity.HasKey(e => new { e.GoodId, e.FilterId });

                entity.ToTable("GoodFilterValue");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.FilterId).HasColumnName("filter_id");

                entity.Property(e => e.FilterValue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("filter_value");

                entity.HasOne(d => d.Filter)
                    .WithMany(p => p.GoodFilterValues)
                    .HasForeignKey(d => d.FilterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodFilterValue_Filters");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.GoodFilterValues)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodFilterValue_Goods");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.ManufacturerId)
                    .ValueGeneratedNever()
                    .HasColumnName("manufacturer_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.ManufacturerCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer_country");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CustomerId })
                    .HasName("PK__Zakazy__4D78AF94D1A3AFA6");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeliveryType).HasColumnName("delivery_type");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zakazy__id_pokup__30F848ED");
            });

            modelBuilder.Entity<OrderContent>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CustomerId, e.GoodId })
                    .HasName("PK__Soderzhi__810D8EBF7A7B6560");

                entity.ToTable("Order_content");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.NumberOfPositions).HasColumnName("number_of_positions");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.OrderContents)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Soderzhim__id_to__31EC6D26");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderContents)
                    .HasForeignKey(d => new { d.OrderId, d.CustomerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Soderzhimoe_zaka__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); //Рандомный комментарий
    }
}
