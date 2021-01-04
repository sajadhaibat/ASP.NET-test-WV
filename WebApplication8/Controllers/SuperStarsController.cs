using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace ASpNEtCoreMain.Controllers
{
    public class SuperStarsController : Controller
    {
        private readonly DataBase _context;

        public SuperStarsController(DataBase context)
        {
            _context = context;
        }

        // GET: SuperStars
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperStars.ToListAsync());
        }

        // GET: SuperStars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superStars = await _context.SuperStars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superStars == null)
            {
                return NotFound();
            }

            return View(superStars);
        }

        // GET: SuperStars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperStars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,remark")] SuperStars superStars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superStars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superStars);
        }

        // GET: SuperStars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superStars = await _context.SuperStars.FindAsync(id);
            if (superStars == null)
            {
                return NotFound();
            }
            return View(superStars);
        }

        // POST: SuperStars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,remark")] SuperStars superStars)
        {
            if (id != superStars.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superStars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperStarsExists(superStars.Id))
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
            return View(superStars);
        }

        // GET: SuperStars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superStars = await _context.SuperStars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superStars == null)
            {
                return NotFound();
            }

            return View(superStars);
        }

        // POST: SuperStars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superStars = await _context.SuperStars.FindAsync(id);
            _context.SuperStars.Remove(superStars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperStarsExists(int id)
        {
            return _context.SuperStars.Any(e => e.Id == id);
        }
    }
}
