using HotelProject.UI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HotelProject.UI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _DashboardSubscribeCountPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = new ResultInstagramFollowersDto  // Changed from defaultResult to result
            {
                follower_count = 0,
                following_count = 0
            };

            try
            {
                // Get ALL values from configuration
                var apiKey = _configuration["RapidApi:Key"];
                var apiHost = _configuration["RapidApi:Host"];
                var username = _configuration["Instagram:Username"];

                // Validate required configuration
                if (string.IsNullOrEmpty(apiKey) ||
                    string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(apiHost))
                {
                    return View(result);  // Now using result
                }

                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://{apiHost}/profile?username={username}"),
                    Headers =
                    {
                        { "x-rapidapi-key", apiKey },
                        { "x-rapidapi-host", apiHost },
                    },
                };

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    // Deserialize as single object, not list
                    result = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body) ?? result;
                }
            }
            catch (Exception ex)
            {
                // Log the error to see what's happening
                Console.WriteLine($"Error fetching Instagram data: {ex.Message}");
            }

            return View(result);
        }
    }
}