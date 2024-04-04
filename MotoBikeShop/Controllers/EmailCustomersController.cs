using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.Models;

namespace MotoBikeShop.Controllers
{
    public class EmailCustomersController : Controller
    {
        private readonly motoBikeVHDbContext _context;

        public EmailCustomersController(motoBikeVHDbContext context)
        {
            _context = context;
        }

      
        // POST: EmailCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitEmail([Bind("IdEmail,Email")] EmailCustomer emailCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailCustomer);
                await _context.SaveChangesAsync();
            }
            return View(emailCustomer);
        }
       

    }
}
