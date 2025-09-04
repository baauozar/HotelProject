using HotelProject.UI.Model.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace HotelProject.UI.Controllers
{
    public class AdminEmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public AdminEmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AdminEmailViewModal());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AdminEmailViewModal model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Load email settings from configuration (including user secrets)
                model.MailServer = _configuration["EmailSettings:MailServer"];
                model.MailPort = int.Parse(_configuration["EmailSettings:MailPort"]);
                model.SenderName = _configuration["EmailSettings:SenderName"];
                model.SenderEmail = _configuration["EmailSettings:SenderEmail"]; // From user secrets
                model.Password = _configuration["EmailSettings:Password"]; // From user secrets

                // Create email message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.SenderName, model.SenderEmail));
                message.To.Add(new MailboxAddress("User", model.ReceiverEmail));
                message.Subject = model.Subject;

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = model.Body
                };
                message.Body = bodyBuilder.ToMessageBody();

                // Send email
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(model.MailServer, model.MailPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(model.SenderEmail, model.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                TempData["Success"] = "Email sent successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to send email: {ex.Message}");
                return View(model);
            }
        }
    }
}