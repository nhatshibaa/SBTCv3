using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBTCv3.Data;
using SBTCv3.Models;

namespace SBTCv3.Controllers
{
    public class AdminController : Controller
    {
        private readonly SBTCv3Context _context;
        public AdminController(SBTCv3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View("Index", "_AdminLayout");
        }

        public IActionResult Ticket()
        {

            return View("Ticket", "_AdminLayout");
        }

        public IActionResult Cart()
        {

            return View("Cart", "_AdminLayout");
        }
        public IActionResult CartCreate()
        {

            return View("~/Views/Admin/Carts/Create.cshtml");
        }
    }

}
