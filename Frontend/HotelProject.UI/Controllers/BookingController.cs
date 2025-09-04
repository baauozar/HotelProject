using FluentValidation;
using HotelProject.UI.Dtos.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    [AllowAnonymous]
    public class BookingController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<CreateBookingDto> _createValidator;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public BookingController(IHttpClientFactory httpClientFactory, IValidator<CreateBookingDto> createValidator, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _createValidator = createValidator;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView(new CreateBookingDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Awaiting Approval";

            if (!await ValidateAsync(createBookingDto, _createValidator, ModelState))
            {
                // Return PartialView for AJAX calls or full view based on request
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView(createBookingDto);
                }
                return View("Index");
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Booking", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Booking created successfully!";
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", $"Error creating booking: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(createBookingDto);
            }
            return View("Index");
        }
    }
}