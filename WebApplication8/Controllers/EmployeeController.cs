using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace ASpNEtCoreMain.Controllers
{
    // Use following action in case you want to authenticate all actions
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly DataBase _context;

        public EmployeeController(DataBase context)
        {
            _context = context;
        }

        // Use following action in case you want to authenticate this actions
        [Authorize]
        public async Task<IActionResult> Index()
        {
           
            // It loads movie relationship data since it has forigen key
            var employees = await _context.Employees.Include(mov =>mov.Movie).Include(s => s.SuperStars).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            // This is to return a select list of another model
            var movies = await _context.Movie.ToListAsync();
            ViewData["movies"] = new SelectList(movies, "Id", "Title");

            // To retun a custom show of select list like (superstart + id) text in 
            // select list
            var superStars = await _context.SuperStars.ToListAsync();
            IEnumerable<SelectListItem> selectList = from s in superStars
                                                     select new SelectListItem
                                                     {
                                                         Value = s.Id.ToString(),
                                                         Text = s.name + " " + s.Id.ToString()
                                                     };
            ViewData["superStars"] = new SelectList(selectList, "Value", "Text") ;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(Employee employee)
        {
            //We can manually map the fields based on requested data.

            //employee.FirstName = HttpContext.Request.Form["Remark"];
            //employee.LastName = HttpContext.Request.Form["Remark"];
            //employee.Position = HttpContext.Request.Form["Remark"];
           
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}