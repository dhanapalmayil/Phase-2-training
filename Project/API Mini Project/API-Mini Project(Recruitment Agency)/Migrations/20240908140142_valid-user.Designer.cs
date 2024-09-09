﻿// <auto-generated />
using API_Mini_Project_Recruitment_Agency_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Mini_Project_Recruitment_Agency_.Migrations
{
    [DbContext(typeof(RecruitmentDbContext))]
    [Migration("20240908140142_valid-user")]
    partial class validuser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Mini_Project_Recruitment_Agency_.Models.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateId"));

                    b.Property<bool>("IsPlaced")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandidateId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("API_Mini_Project_Recruitment_Agency_.Models.Skillset", b =>
                {
                    b.Property<int>("SkillsetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillsetId"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillsetId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Skillsets");
                });

            modelBuilder.Entity("API_Mini_Project_Recruitment_Agency_.Models.ValidUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValidUsers");
                });

            modelBuilder.Entity("API_Mini_Project_Recruitment_Agency_.Models.Skillset", b =>
                {
                    b.HasOne("API_Mini_Project_Recruitment_Agency_.Models.Candidate", "Candidate")
                        .WithMany("Skillsets")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("API_Mini_Project_Recruitment_Agency_.Models.Candidate", b =>
                {
                    b.Navigation("Skillsets");
                });
#pragma warning restore 612, 618
        }
    }
}
