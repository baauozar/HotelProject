namespace HotelProject.UI.Model.Setting
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
    }
}
