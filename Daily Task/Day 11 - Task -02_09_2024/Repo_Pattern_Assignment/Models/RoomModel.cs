using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo_Pattern_Assignment.Models
{
    public class RoomModel
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        public int? RoomNo { get; set; }

        [Required]
        public string? RoomType { get; set; }

        [Range(500,5000,ErrorMessage ="Room must be greater than 500 and less than 5000")]
        public decimal RoomPrice { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]

        public HotelModel? HotelModel { get; set; }


    }
}
