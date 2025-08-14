using System.ComponentModel.DataAnnotations;

namespace HotelProject.UI.Dtos.Service
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Service Icon is required.")]
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
    }
}
