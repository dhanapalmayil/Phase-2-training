﻿// <auto-generated />
using API_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Demo.Migrations
{
    [DbContext(typeof(EmployeeOrgContext))]
    partial class EmployeeOrgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Demo.Models.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empId"));

                    b.Property<int>("OrgId")
                        .HasColumnType("int");

                    b.Property<string>("empName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empSalary")
                        .HasColumnType("int");

                    b.HasKey("empId");

                    b.HasIndex("OrgId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API_Demo.Models.Organization", b =>
                {
                    b.Property<int>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrgId"));

                    b.Property<string>("OrgName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrgId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("API_Demo.Models.ValidUser", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("ValidUsers");
                });

            modelBuilder.Entity("API_Demo.Models.Employee", b =>
                {
                    b.HasOne("API_Demo.Models.Organization", "organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("organization");
                });

            modelBuilder.Entity("API_Demo.Models.Organization", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
