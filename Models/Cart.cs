using System.ComponentModel.DataAnnotations;

namespace Hotles.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdRooms { get; set; }
        [Required]
        public int IdRoomDetalis { get; set; }
        [Required]
        public int IdHotle { get; }
        [Required]  
        public decimal Price { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
