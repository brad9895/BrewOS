using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewOS.Data;
using BrewOS.Models.Vessels;
using OneWire;

namespace BrewOS.Controllers
{
    public class FermentersController : Controller
    {
        private readonly BrewOSContext _context;

        public FermentersController(BrewOSContext context)
        {
            _context = context;
        }

        // GET: Fermenters1
        public async Task<IActionResult> Index()
        {
            var brewOSContext = _context.Fermenters
                .Include(f => f.TempSensor)
                .Include(f => f.Wort)
                .Include(f => f.Wort._Recipe)
                .Include(f => f.Wort._Recipe.Style);

            OneWireBus bus = OneWireBus.Instance;

            foreach (var item in brewOSContext)
            {
                if (!bus.Devices.Select(x => x.Address).Contains(item.Address))
                    bus.Devices.Add(new TempSensorDS18B20(item.TempSensor.Address));
            }


            return View(await brewOSContext.ToListAsync());
        }

        // GET: Fermenters1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermenter = await _context.Fermenters
                .Include(f => f.TempSensor)
                .Include(f => f.Wort)
                .FirstOrDefaultAsync(m => m.FermenterID == id);
            if (fermenter == null)
            {
                return NotFound();
            }

            return View(fermenter);
        }

        // GET: Fermenters1/Create
        public IActionResult Create()
        {
            ViewData["Address"] = new SelectList(_context.Sensors, "Address", "Name");
            ViewData["BeerID"] = new SelectList(_context.BrewHistory, "BeerID", "RecipeName");
            return View();
        }

        // POST: Fermenters1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FermenterID,Name,TargetTemp,BeerID,Address")] Fermenter fermenter)
        {
            if (ModelState.IsValid)
            {
                fermenter.Wort = await _context.BrewHistory.SingleOrDefaultAsync(x => x.BeerID == fermenter.BeerID);
                fermenter.TempSensor = await _context.Sensors.SingleOrDefaultAsync(x => x.Address == fermenter.Address);

                _context.Fermenters.Add(fermenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Address"] = new SelectList(_context.Sensors, "Address", "Address", fermenter.Address);
            ViewData["BeerID"] = new SelectList(_context.BrewHistory, "BeerID", "BeerID", fermenter.BeerID);
            return View(fermenter);
        }

        // GET: Fermenters1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermenter = await _context.Fermenters.FindAsync(id);
            if (fermenter == null)
            {
                return NotFound();
            }
            ViewData["Address"] = new SelectList(_context.Sensors, "Address", "Address", fermenter.Address);
            ViewData["BeerID"] = new SelectList(_context.BrewHistory, "BeerID", "BeerID", fermenter.BeerID);
            return View(fermenter);
        }

        // POST: Fermenters1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FermenterID,Name,TargetTemp,BeerID,Address")] Fermenter fermenter)
        {
            if (id != fermenter.FermenterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fermenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FermenterExists(fermenter.FermenterID))
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
            ViewData["Address"] = new SelectList(_context.Sensors, "Address", "Address", fermenter.Address);
            ViewData["BeerID"] = new SelectList(_context.BrewHistory, "BeerID", "BeerID", fermenter.BeerID);
            return View(fermenter);
        }

        // GET: Fermenters1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermenter = await _context.Fermenters
                .Include(f => f.TempSensor)
                .Include(f => f.Wort)
                .FirstOrDefaultAsync(m => m.FermenterID == id);
            if (fermenter == null)
            {
                return NotFound();
            }

            return View(fermenter);
        }

        // POST: Fermenters1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fermenter = await _context.Fermenters.FindAsync(id);
            _context.Fermenters.Remove(fermenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FermenterExists(int id)
        {
            return _context.Fermenters.Any(e => e.FermenterID == id);
        }
    }
}
