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
    public class BusinessOwnerController : Controller
    {
        private readonly ScheduDbContext _context;

        public BusinessOwnerController(ScheduDbContext context)
        {
            _context = context;
        }

        // GET: BusinessOwner
        public async Task<IActionResult> Index()
        {
              return View(await _context.BusinessesOwners.ToListAsync());
        }

        // GET: BusinessOwner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessesOwners == null)
            {
                return NotFound();
            }

            var businessOwner = await _context.BusinessesOwners
                .FirstOrDefaultAsync(m => m.BusinessOwnerId == id);
            if (businessOwner == null)
            {
                return NotFound();
            }

            return View(businessOwner);
        }

        // GET: BusinessOwner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessOwner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessOwnerId,OwnerName,OwnerPhone,OwnerEmail,RegistryDate,IsActive")] BusinessOwner businessOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessOwner);
        }

        // GET: BusinessOwner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessesOwners == null)
            {
                return NotFound();
            }

            var businessOwner = await _context.BusinessesOwners.FindAsync(id);
            if (businessOwner == null)
            {
                return NotFound();
            }
            return View(businessOwner);
        }

        // POST: BusinessOwner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessOwnerId,OwnerName,OwnerPhone,OwnerEmail,RegistryDate,IsActive")] BusinessOwner businessOwner)
        {
            if (id != businessOwner.BusinessOwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessOwnerExists(businessOwner.BusinessOwnerId))
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
            return View(businessOwner);
        }

        // GET: BusinessOwner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessesOwners == null)
            {
                return NotFound();
            }

            var businessOwner = await _context.BusinessesOwners
                .FirstOrDefaultAsync(m => m.BusinessOwnerId == id);
            if (businessOwner == null)
            {
                return NotFound();
            }

            return View(businessOwner);
        }

        // POST: BusinessOwner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessesOwners == null)
            {
                return Problem("Entity set 'ScheduDbContext.BusinessesOwners'  is null.");
            }
            var businessOwner = await _context.BusinessesOwners.FindAsync(id);
            if (businessOwner != null)
            {
                _context.BusinessesOwners.Remove(businessOwner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessOwnerExists(int id)
        {
          return _context.BusinessesOwners.Any(e => e.BusinessOwnerId == id);
        }
    }
}
