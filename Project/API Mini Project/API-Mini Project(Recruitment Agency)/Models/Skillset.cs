using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Mini_Project_Recruitment_Agency_.Models
{
    public class Skillset
    {
        [Key]
        public int SkillsetId { get; set; }
        public string? SkillName { get; set; }

        // Foreign key
        public int CandidateId { get; set; }
        [ForeignKey("CandidateId")]

        // Navigation property
        public Candidate? Candidate { get; set; }
    }
}
