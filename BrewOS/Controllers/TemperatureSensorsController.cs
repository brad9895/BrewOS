using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewOS.Data;
using BrewOS.Models.Sensors.TemperatureSensors;

namespace BrewOS.Controllers
{
    public class TemperatureSensorsController : Controller
    {
        private readonly BrewOSContext _context;

        public TemperatureSensorsController(BrewOSContext context)
        {
            _context = context;

            context.Sensors.ToList();
        }

        // GET: TemperatureSensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sensors.ToListAsync());
        }

        // GET: TemperatureSensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureSensor = await _context.Sensors
                .SingleOrDefaultAsync(m => m.Address == id);
            if (temperatureSensor == null)
            {
                return NotFound();
            }

            return View(temperatureSensor);
        }

        // GET: TemperatureSensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TemperatureSensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Address,Name")] TemperatureSensor temperatureSensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatureSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temperatureSensor);
        }

        // GET: TemperatureSensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureSensor = await _context.Sensors.SingleOrDefaultAsync(m => m.Address == id);
            if (temperatureSensor == null)
            {
                return NotFound();
            }
            return View(temperatureSensor);
        }

        // POST: TemperatureSensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Address,Name")] TemperatureSensor temperatureSensor)
        {
            if (id != temperatureSensor.Address)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatureSensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureSensorExists(temperatureSensor.Address))
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
            return View(temperatureSensor);
        }

        // GET: TemperatureSensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureSensor = await _context.Sensors
                .SingleOrDefaultAsync(m => m.Address == id);
            if (temperatureSensor == null)
            {
                return NotFound();
            }

            return View(temperatureSensor);
        }

        // POST: TemperatureSensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var temperatureSensor = await _context.Sensors.SingleOrDefaultAsync(m => m.Address == id);
            _context.Sensors.Remove(temperatureSensor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureSensorExists(string id)
        {
            return _context.Sensors.Any(e => e.Address == id);
        }
    }
}
