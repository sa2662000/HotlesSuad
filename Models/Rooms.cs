﻿using System.ComponentModel.DataAnnotations;

namespace Hotles.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(100)]
        public string Images { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int IdHotel { get; set; }
    }
}
