using Microsoft.AspNetCore.Mvc;
using SBTCv3.Models;
using System.Diagnostics;

namespace SBTCv3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult faq()
        {
            return View();
        }

        public IActionResult term()
        {
            return View();
        }
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult travel()
        {
            return View();
        }

        public IActionResult ticket()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}