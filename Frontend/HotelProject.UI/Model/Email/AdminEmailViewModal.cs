using System.ComponentModel.DataAnnotations;

namespace HotelProject.UI.Model.Email
{
    public class AdminEmailViewModal
    {
        [Required]
        [EmailAddress]
        public string? ReceiverEmail { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Body { get; set; }


        public string? MailServer { get; set; }
        public int MailPort { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? Password { get; set; }
    }
}
