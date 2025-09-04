using Microsoft.AspNetCore.Identity;

namespace HotelProject.UI.Model.Role
{
    public class AddRoleViewModel : IdentityRole
    {
        public string? RoleName { get; set; }
    }
}
