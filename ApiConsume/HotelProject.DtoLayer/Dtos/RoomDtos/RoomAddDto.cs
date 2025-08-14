using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
    public class RoomAddDto
    {
       [Required(ErrorMessage ="Lutfen oda numarasini yaziniz")]
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lutfen oda fiyatini yaziniz")]
        public int Price { get; set; }
        [return: Required(ErrorMessage = "Lutfen oda basligini yaziniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lutfen oda tipini seciniz")]
        public string? BedCount { get; set; }
        [return: Required(ErrorMessage = "Lutfen banyo sayisini seciniz")]
        public string? BathCount { get; set; }
        public string? wifi { get; set; }
        public string? Description { get; set; }

    }
}
