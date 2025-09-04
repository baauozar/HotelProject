using HotelProject.UI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.UI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;

            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // First API call
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/DashboardWidgets/StaffCount");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                ViewBag.staffcount = jsonData;
            }

            // Second API call - reuse the same client
            var ResponseMessage2 = await client.GetAsync($"{_apiBaseUrl}/api/DashboardWidgets/BookingCount");
            if (ResponseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await ResponseMessage2.Content.ReadAsStringAsync();
                ViewBag.bookingcount = jsonData2;
            }
            // Third API call - reuse the same client
            var ResponseMessage3 = await client.GetAsync($"{_apiBaseUrl}/api/DashboardWidgets/AppUserCount");
            if (ResponseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await ResponseMessage3.Content.ReadAsStringAsync();
                ViewBag.AppUserCount = jsonData3;
            }
            // Fourth API call - reuse the same client
            var ResponseMessage4 = await client.GetAsync($"{_apiBaseUrl}/api/DashboardWidgets/RoomCount");
            if (ResponseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await ResponseMessage4.Content.ReadAsStringAsync();
                ViewBag.RoomCount = jsonData4;
            }

            return View();
        }
    }
}