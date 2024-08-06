using CricketPlayer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CricketPlayer.UI.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient _httpClient;

        private static string BaseUrl = "http://localhost:5255";

        public PlayerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/Player/GetAll");

            var jsonContent = await response.Content.ReadAsStringAsync();

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonContent);

            return View(players);
        }
    }
}