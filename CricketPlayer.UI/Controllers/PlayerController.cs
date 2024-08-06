using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CricketPlayer.UI.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}