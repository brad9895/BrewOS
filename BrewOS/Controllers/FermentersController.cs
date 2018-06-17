using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewOS.Data;
using BrewOS.Models.Vessels;
using BrewOS.Models.Sensors.TemperatureSensors;

namespace BrewOS.Controllers
{
    public class FermentersController : Controller
    {
        private readonly BrewOSContext _context;

        public FermentersController(BrewOSContext context)
        {
            _context = context;
        }

        // GET: Fermenters
        //public async Task<IActionResult> Index()
        //{
        //    var brewOSContext = _context.Fermenters.Include(f => f.TempSensor).Include(f => f.Wort);
        //    return View(await brewOSContext.ToListAsync());
        //}

        // GET: Fermenters/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fermenter = await _context.Fermenters
        //        .Include(f => f.TempSensor)
        //        .Include(f => f.Wort)
        //        .SingleOrDefaultAsync(m => m.Name == id);
        //    if (fermenter == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fermenter);
        //}

        // GET: Fermenters/Create
        //public IActionResult Create()
        //{
        //    ViewData["SensorID"] = new SelectList(_context.Set<TemperatureSensor>(), "SensorID", "SensorID");
        //    ViewData["BeerID"] = new SelectList(_context.Brews, "BeerID", "BeerID");
        //    return View();
        //}

        // POST: Fermenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,TargetTemp,BeerID,SensorID")] Fermenter fermenter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(fermenter);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SensorID"] = new SelectList(_context.Set<TemperatureSensor>(), "SensorID", "SensorID", fermenter.SensorID);
        //    ViewData["BeerID"] = new SelectList(_context.Brews, "BeerID", "BeerID", fermenter.BeerID);
        //    return View(fermenter);
        //}

        // GET: Fermenters/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fermenter = await _context.Fermenters.SingleOrDefaultAsync(m => m.Name == id);
        //    if (fermenter == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SensorID"] = new SelectList(_context.Set<TemperatureSensor>(), "SensorID", "SensorID", fermenter.SensorID);
        //    ViewData["BeerID"] = new SelectList(_context.Brews, "BeerID", "BeerID", fermenter.BeerID);
        //    return View(fermenter);
        //}

        // POST: Fermenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Name,TargetTemp,BeerID,SensorID")] Fermenter fermenter)
        //{
        //    if (id != fermenter.Name)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(fermenter);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FermenterExists(fermenter.Name))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SensorID"] = new SelectList(_context.Set<TemperatureSensor>(), "SensorID", "SensorID", fermenter.SensorID);
        //    ViewData["BeerID"] = new SelectList(_context.Brews, "BeerID", "BeerID", fermenter.BeerID);
        //    return View(fermenter);
        //}

        // GET: Fermenters/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fermenter = await _context.Fermenters
        //        .Include(f => f.TempSensor)
        //        .Include(f => f.Wort)
        //        .SingleOrDefaultAsync(m => m.Name == id);
        //    if (fermenter == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fermenter);
        //}

        // POST: Fermenters/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var fermenter = await _context.Fermenters.SingleOrDefaultAsync(m => m.Name == id);
        //    _context.Fermenters.Remove(fermenter);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FermenterExists(string id)
        //{
        //    return _context.Fermenters.Any(e => e.Name == id);
        //}
    }
}
