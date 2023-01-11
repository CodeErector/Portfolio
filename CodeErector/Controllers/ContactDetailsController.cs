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

        // GET: ContactDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.ContactDetails.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
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

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails.FindAsync(id);
            if (contactDetails == null)
            {
                return NotFound();
            }
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,CDate,CustName,massage")] ContactDetails contactDetails)
        {
            if (id != contactDetails.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailsExists(contactDetails.ContactId))
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
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactDetails == null)
            {
                return Problem("Entity set 'projectDbContext.ContactDetails'  is null.");
            }
            var contactDetails = await _context.ContactDetails.FindAsync(id);
            if (contactDetails != null)
            {
                _context.ContactDetails.Remove(contactDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDetailsExists(int id)
        {
          return _context.ContactDetails.Any(e => e.ContactId == id);
        }
    }
}
