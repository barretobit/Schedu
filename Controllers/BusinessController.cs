using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedu.Models;

namespace Schedu.Controllers
{
    public class BusinessController : Controller
    {
        private readonly BusinessDbContext _context;

        public BusinessController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
              return View(await _context.Businesses.ToListAsync());
        }

        // GET: Business/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
            return View(new Business());
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessId,BusinessName,BusinessPhone,BusinessEmail,OwnerName,OwnerPhone,OwnerEmail,RegistryDate")] Business business)
        {
            if (ModelState.IsValid)
            {
                _context.Add(business);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(business);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return View(business);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessId,BusinessName,BusinessPhone,BusinessEmail,OwnerName,OwnerPhone,OwnerEmail,RegistryDate")] Business business)
        {
            if (id != business.BusinessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.BusinessId))
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
            return View(business);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Businesses == null)
            {
                return NotFound();
            }

            var business = await _context.Businesses
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Businesses == null)
            {
                return Problem("Entity set 'BusinessDbContext.Businesses'  is null.");
            }
            var business = await _context.Businesses.FindAsync(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(int id)
        {
          return _context.Businesses.Any(e => e.BusinessId == id);
        }
    }
}
