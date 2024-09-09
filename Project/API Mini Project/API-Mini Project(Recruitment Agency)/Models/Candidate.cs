using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Mini_Project_Recruitment_Agency_.Models
{

    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string? Name { get; set; }
        public bool IsPlaced { get; set; }

        // Navigation property
        public ICollection<Skillset>? Skillsets { get; set; }
    }
    
}
