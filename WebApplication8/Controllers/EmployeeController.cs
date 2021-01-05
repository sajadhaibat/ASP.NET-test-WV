using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;

namespace ASpNEtCoreMain.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataBase _context;

        public EmployeeController(DataBase context)
        {
            _context = context;
        }

   


        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }
    }
}