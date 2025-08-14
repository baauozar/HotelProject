using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Lutfen oda numarasini yaziniz")]
        public string? RoomNumber { get; set; }
        [Required(ErrorMessage = "Lutfen oda kapak resmini seciniz")]
        public string? RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lutfen oda fiyatini yaziniz")]
         public int Price { get; set; }

        [Required(ErrorMessage = "Lutfen oda basligini yaziniz")]
        [StringLength(100, ErrorMessage = "Oda basligi 100 karakterden uzun olmamalidir.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lutfen oda tipini seciniz")]
        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Lutfen banyo sayisini seciniz")]
        public string? BathCount { get; set; }

        public string? wifi { get; set; }
        [Required(ErrorMessage = "Lutfen oda aciklamasini yaziniz")]
        public string? Description { get; set; }

    }
}
