using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeErector.Models;

namespace CodeErector.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly projectDbContext _context;

        public ContactDetailsController(projectDbContext context)
        {
            _context = context;
        }

        // GET: ContactDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,CDate,CustName,massage")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetails);
        }
    }
}