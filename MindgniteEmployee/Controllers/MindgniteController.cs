using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MindgniteEmployee.Data;
using MindgniteEmployee.Models;

namespace MindgniteEmployee.Controllers
{
    public class MindgniteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MindgniteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mindgnite
        public async Task<IActionResult> Index()
        {
              return _context.MindgniteViewModel != null ? 
                          View(await _context.MindgniteViewModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MindgniteViewModel'  is null.");
        }

        // GET: Mindgnite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MindgniteViewModel == null)
            {
                return NotFound();
            }

            var mindgniteViewModel = await _context.MindgniteViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mindgniteViewModel == null)
            {
                return NotFound();
            }

            return View(mindgniteViewModel);
        }

        // GET: Mindgnite/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mindgnite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NRC_Number,JoinDate,EmployeeNo,Address,City")] MindgniteViewModel mindgniteViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mindgniteViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mindgniteViewModel);
        }

        // GET: Mindgnite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MindgniteViewModel == null)
            {
                return NotFound();
            }

            var mindgniteViewModel = await _context.MindgniteViewModel.FindAsync(id);
            if (mindgniteViewModel == null)
            {
                return NotFound();
            }
            return View(mindgniteViewModel);
        }

        // POST: Mindgnite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NRC_Number,JoinDate,EmployeeNo,Address,City")] MindgniteViewModel mindgniteViewModel)
        {
            if (id != mindgniteViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mindgniteViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MindgniteViewModelExists(mindgniteViewModel.Id))
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
            return View(mindgniteViewModel);
        }

        // GET: Mindgnite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MindgniteViewModel == null)
            {
                return NotFound();
            }

            var mindgniteViewModel = await _context.MindgniteViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mindgniteViewModel == null)
            {
                return NotFound();
            }

            return View(mindgniteViewModel);
        }

        // POST: Mindgnite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MindgniteViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MindgniteViewModel'  is null.");
            }
            var mindgniteViewModel = await _context.MindgniteViewModel.FindAsync(id);
            if (mindgniteViewModel != null)
            {
                _context.MindgniteViewModel.Remove(mindgniteViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MindgniteViewModelExists(int id)
        {
          return (_context.MindgniteViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
