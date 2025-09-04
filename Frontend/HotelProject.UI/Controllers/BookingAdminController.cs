using HotelProject.UI.Dtos.BookingDto;
using HotelProject.UI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.UI.Controllers
{

    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public BookingAdminController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Booking");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var bookingList = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(bookingList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error retrieving staff data.");
            }
            return View();
        }
        public async Task<IActionResult> Approved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Booking/BookingStatusChangeApproved/{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error approving booking.");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Decline(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Booking/BookingStatusChangeDecline/{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error approving booking.");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Waiting(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Booking/BookingStatusChangeWaiting/{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error approving booking.");
            }
            return RedirectToAction("Index");
        }
    }
}
