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
    public class BeersController : Controller
    {
        private readonly BrewOSContext _context;

        public BeersController(BrewOSContext context)
        {
            _context = context;
        }

        // GET: Beers
        public async Task<IActionResult> Index()
        {
            var brewOSContext = _context.BrewHistory.Include(b => b._Recipe);
            return View(await brewOSContext.ToListAsync());
        }

        // GET: Beers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.BrewHistory
                .Include(b => b._Recipe)
                .FirstOrDefaultAsync(m => m.BeerID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            ViewData["RecipeID"] = new SelectList(_context.RecipeCatalog, "RecipeID", "RecipeName");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeerID,RecipeName,RecipeID,ABV,BrewDate,RackDate,KegDate,InitalGravity,FinalGravity,Description,Active")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeID"] = new SelectList(_context.RecipeCatalog, "RecipeID", "RecipeID", beer.RecipeID);
            return View(beer);
        }

        // GET: Beers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.BrewHistory.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            ViewData["RecipeID"] = new SelectList(_context.RecipeCatalog, "RecipeID", "RecipeID", beer.RecipeID);
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeerID,RecipeName,RecipeID,ABV,BrewDate,RackDate,KegDate,InitalGravity,FinalGravity,Description,Active")] Beer beer)
        {
            if (id != beer.BeerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.BeerID))
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
            ViewData["RecipeID"] = new SelectList(_context.RecipeCatalog, "RecipeID", "RecipeID", beer.RecipeID);
            return View(beer);
        }

        // GET: Beers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.BrewHistory
                .Include(b => b._Recipe)
                .FirstOrDefaultAsync(m => m.BeerID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.BrewHistory.FindAsync(id);
            _context.BrewHistory.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerExists(int id)
        {
            return _context.BrewHistory.Any(e => e.BeerID == id);
        }
    }
}
