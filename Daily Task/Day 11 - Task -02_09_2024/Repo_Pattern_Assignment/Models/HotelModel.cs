using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern_Assignment.Models
{
    public class HotelModel
    {
        [Key]
        public int HotelId { get; set; }

        [StringLength(20,ErrorMessage ="Hotel Name must be greater than 5 and less than 20",MinimumLength =5)]
        public string? HotelName { get; set; }

        public ICollection<RoomModel>? Room { get; set; }
    


    }
}
