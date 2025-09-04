using System.ComponentModel.DataAnnotations;

namespace HotelProject.UI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Enter ur Password")]
        public string? Password { get; set; }
    }
}
