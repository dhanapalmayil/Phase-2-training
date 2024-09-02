using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repo_Pattern_Assignment.Models
{
    public class HotellDbContext : DbContext
    {
        public DbSet<HotelModel> Hotels { get; set; }

        public DbSet<RoomModel> Rooms { get; set; }

        public HotellDbContext(DbContextOptions <HotellDbContext> options) : base(options)
      { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=MVC_Dhanapal_Hotel;integrated security=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelModel>()
                .HasData(new HotelModel() { HotelId = 11, HotelName = "Siddarth Hotel" },
                new HotelModel() { HotelId=12,HotelName="Prathik Hotel"}
                );
            modelBuilder.Entity<RoomModel>()

                .HasData(new RoomModel() { RoomID = 1, RoomNo = 111, RoomPrice = 800, RoomType = "Non Ac" },
                new RoomModel() { RoomID = 2, RoomNo = 112, RoomPrice = 2500, RoomType = " Ac" });

            modelBuilder.Entity<RoomModel>()
                .Property(p => p.RoomPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<HotelModel>()
                .HasMany(o => o.Room).WithOne(c => c.HotelModel).HasForeignKey(c => c.HotelId);
        }
    }
}
