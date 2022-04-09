using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBTCv3.Data;
using SBTCv3.Models;
using System.Diagnostics;

namespace SBTCv3.Controllers
{
    public class HomeController : Controller
    {
        private readonly SBTCv3Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SBTCv3Context context, ILogger<HomeController> logger)
        {
            _context = context;
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
        public async Task<IActionResult> travel()
        {
            return View(await _context.Ticket.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CartCreate([Bind("Id,Email,IdentityCard,idTicket,Quantity,createTime,exprired")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return View("~/Views/Admin/Carts/Index.cshtml", await _context.Cart.ToListAsync());
            }
            return View("~/Views/Home/travel.cshtml", cart);
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