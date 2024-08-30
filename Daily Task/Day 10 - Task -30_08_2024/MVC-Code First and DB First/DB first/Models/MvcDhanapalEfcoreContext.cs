using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_first.Models;

public partial class MvcDhanapalEfcoreContext : DbContext
{
    public MvcDhanapalEfcoreContext()
    {
    }

    public MvcDhanapalEfcoreContext(DbContextOptions<MvcDhanapalEfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=MVC_Dhanapal_EFCore;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId);

            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.HasIndex(e => e.CustId, "IX_orders_custId");

            entity.Property(e => e.CustId).HasColumnName("custId");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders).HasForeignKey(d => d.CustId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
