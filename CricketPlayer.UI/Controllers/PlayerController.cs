using CricketPlayer.Domain.Enums;
using CricketPlayer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/Player/GetOrderedListByRank");

            var jsonContent = await response.Content.ReadAsStringAsync();

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonContent);

            return View(players);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Player player = new Player();

            IEnumerable<SelectListItem> PlayerRoleLIst = Enum.GetValues(typeof(PlayerRole))
                .Cast<PlayerRole>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });

            IEnumerable<SelectListItem> BattingStyleList = Enum.GetValues(typeof(BattingStyle))
                .Cast<BattingStyle>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });

            IEnumerable<SelectListItem> BowlingStyleList = Enum.GetValues(typeof(BowlingStyle))
                .Cast<BowlingStyle>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });


            ViewData["PlayerRoleLIst"] = PlayerRoleLIst;
            ViewData["BattingStyleList"] = BattingStyleList;
            ViewData["BowlingStyleList"] = BowlingStyleList;

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
           var content = new StringContent(JsonConvert.SerializeObject(player), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/api/Player/Create", content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/Player/GetById?id={id}");

            var jsonContent = await response.Content.ReadAsStringAsync();

            Player player = JsonConvert.DeserializeObject<Player>(jsonContent);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            var content = new StringContent(JsonConvert.SerializeObject(player), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BaseUrl}/api/Player/Update", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }
    }
}