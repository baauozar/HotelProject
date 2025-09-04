using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.UI.ViewComponents.AdminContact
{
    public class _SideBarAdminContactPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;


        public _SideBarAdminContactPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                // Get inbox count
                var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Contact/GetContactCount");
                int contactCount = 0;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    contactCount = JsonConvert.DeserializeObject<int>(jsonData);
                }

                // You can also get sent count here if needed
                var sentResponse = await client.GetAsync($"{_apiBaseUrl}/api/SendMessage/GetSenderMessageCount");
                int sentCount = 0;

                if (sentResponse.IsSuccessStatusCode)
                {
                    var jsonData = await sentResponse.Content.ReadAsStringAsync();
                    sentCount = JsonConvert.DeserializeObject<int>(jsonData);
                }

                // Pass data to view
                ViewBag.ContactCount = contactCount;
                ViewBag.SentCount = sentCount;

                return View();
            }
            catch (Exception ex)
            {
                // Log error if you have logging
                ViewBag.ContactCount = 0;
                ViewBag.SentCount = 0;
                return View();
            }
        }
    }
}