using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Data
{
    public class DataBase : IdentityDbContext
    {
        public DataBase (DbContextOptions<DataBase> options)
         : base(options)
        {
        }

        public DbSet<Models.Movie> Movie { get; set; }
        public DbSet<Models.SuperStars> SuperStars { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
    }
}
