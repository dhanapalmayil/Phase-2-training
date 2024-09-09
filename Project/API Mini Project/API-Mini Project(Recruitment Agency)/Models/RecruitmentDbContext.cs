using Microsoft.EntityFrameworkCore;
namespace API_Mini_Project_Recruitment_Agency_.Models
{
    public class RecruitmentDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }

        public DbSet<ValidUser> Users { get; set; }

        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.Skillsets)
                .WithOne(s => s.Candidate)
                .HasForeignKey(s => s.CandidateId);
        }

    }
}
