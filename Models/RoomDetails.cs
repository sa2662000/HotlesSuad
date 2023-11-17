using System.ComponentModel.DataAnnotations;

namespace Hotles.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Images1 { get; set; }
        [Required]
        [StringLength(100)]
        public string Images2 { get; set; }
        [Required]
        [StringLength(100)]
        public string Images3 { get; set; }
        [Required]
        [StringLength(50)]
        public string Futures { get; set; }
        [Required]
        [StringLength(50)]
        public string Food { get; set;}
        [Required]
        public int IdRooms { get; set;}
        [Required]
        public int IdHotle { get;}
    }
}
