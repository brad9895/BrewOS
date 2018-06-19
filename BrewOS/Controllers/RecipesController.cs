﻿using System;
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
    public class RecipesController : Controller
    {
        private readonly BrewOSContext _context;

        public RecipesController(BrewOSContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var brewOSContext = _context
                .RecipeCatalog
                .Include(r => r.Style)
                .Include(r => r.GrainBill);
            return View(await brewOSContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.RecipeCatalog
                .Include(r => r.Style)
                .Include(r => r.GrainBill)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["StyleName"] = new SelectList(_context.Styles, "StyleName", "StyleName");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,RecipeName,StyleName,TargetGravity,MashingTemp,SuggestedFermTemp")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StyleName"] = new SelectList(_context.Styles, "StyleName", "StyleName", recipe.StyleName);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.RecipeCatalog.Include(r => r.Style).Include(r => r.GrainBill).SingleOrDefaultAsync(x => x.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["StyleName"] = new SelectList(_context.Styles, "StyleName", "StyleName", recipe.StyleName);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,RecipeName,StyleName,TargetGravity,MashingTemp,SuggestedFermTemp")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
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
            ViewData["StyleName"] = new SelectList(_context.Styles, "StyleName", "StyleName", recipe.StyleName);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.RecipeCatalog
                .Include(r => r.Style)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.RecipeCatalog.FindAsync(id);
            _context.RecipeCatalog.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.RecipeCatalog.Any(e => e.RecipeID == id);
        }
    }
}
