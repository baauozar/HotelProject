using System.ComponentModel.DataAnnotations;

namespace HotelProject.UI.Dtos.Register
{
    public class CreateNewUserDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

      



    }
}
