using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoree.Models;

public partial class BookstoreContext : DbContext
{
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FH8E2CK\\SQLEXPRESS;Database=bookstore; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("addressID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("street");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("clientID");
            entity.Property(e => e.AddressId).HasColumnName("addressID");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("e-mail");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");

            entity.HasOne(d => d.Address).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Client_Address");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Order_Client");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productID");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nameProduct");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("price");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Product_Supplier");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SipplierId);

            entity.ToTable("Supplier");

            entity.Property(e => e.SipplierId)
                .ValueGeneratedNever()
                .HasColumnName("sipplierID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
