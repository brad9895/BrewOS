using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewOS.Data;
using BrewOS.Models.Beers;

namespace BrewOS.Controllers
{
    public class GrainRecipeItemsController : Controller
    {
        private readonly BrewOSContext _context;

        public GrainRecipeItemsController(BrewOSContext context)
        {
            _context = context;
        }

        // GET: GrainRecipeItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrainRecipeItem.ToListAsync());
        }

        // GET: GrainRecipeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grainRecipeItem = await _context.GrainRecipeItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (grainRecipeItem == null)
            {
                return NotFound();
            }

            return View(grainRecipeItem);
        }

        // GET: GrainRecipeItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrainRecipeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Amount")] GrainRecipeItem grainRecipeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grainRecipeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grainRecipeItem);
        }

        // GET: GrainRecipeItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grainRecipeItem = await _context.GrainRecipeItem.FindAsync(id);
            if (grainRecipeItem == null)
            {
                return NotFound();
            }
            return View(grainRecipeItem);
        }

        // POST: GrainRecipeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Amount")] GrainRecipeItem grainRecipeItem)
        {
            if (id != grainRecipeItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grainRecipeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrainRecipeItemExists(grainRecipeItem.ID))
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
            return View(grainRecipeItem);
        }

        // GET: GrainRecipeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grainRecipeItem = await _context.GrainRecipeItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (grainRecipeItem == null)
            {
                return NotFound();
            }

            return View(grainRecipeItem);
        }

        // POST: GrainRecipeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grainRecipeItem = await _context.GrainRecipeItem.FindAsync(id);
            _context.GrainRecipeItem.Remove(grainRecipeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrainRecipeItemExists(int id)
        {
            return _context.GrainRecipeItem.Any(e => e.ID == id);
        }
    }
}
