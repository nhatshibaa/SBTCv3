using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBTCv3.Data;
using SBTCv3.Models;
using System.Diagnostics;

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

        public async Task<IActionResult> TicketAsync()
        {

            return View("~/Views/Admin/Tickets/Index.cshtml", await _context.Ticket.ToListAsync());
        }

        public async Task<IActionResult> CartAsync()
        {
            return View("~/Views/Admin/Carts/Index.cshtml", await _context.Cart.ToListAsync());
        }
        public IActionResult CartCreate()
        {
            return View("~/Views/Admin/Carts/Create.cshtml");
        }
        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View("~/Views/Admin/Carts/Details.cshtml", cart);
        }
        public async Task<IActionResult> CartDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Carts/Details.cshtml", cart);
        }
        public async Task<IActionResult> CartEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Carts/Edit.cshtml", cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CartEdit(int id, [Bind("Id,Email,IdentityCard,idTicket,Quantity,createTime,exprired")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Carts/Index.cshtml",cart);
        }

        public async Task<IActionResult> CartDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Carts/Delete.cshtml", cart);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }

        public IActionResult TicketCreate()
        {
            return View("~/Views/Admin/Tickets/Create.cshtml");
        }
        public async Task<IActionResult> TicketDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Tickets/Details.cshtml", ticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketCreate([Bind("id,name,price,startLocation,endLocation,quantity,Time")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Tickets/Create.cshtml", ticket);
        }
        public async Task<IActionResult> TicketEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Tickets/Edit.cshtml", ticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketEdit(int id, [Bind("id,name,price,startLocation,endLocation,quantity,Time")] Ticket ticket)
        {
            if (id != ticket.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Tickets/Edit.cshtml", ticket);
        }
        public async Task<IActionResult> TicketDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Tickets/Delete.cshtml", ticket);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketDeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.id == id);
        }
    }

}
