using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Data
{
    public class DataBase : DbContext
    {
        public DataBase (DbContextOptions<DataBase> options)
         : base(options)
        {
        }

        public DbSet<Models.Movie> Movie { get; set; }
        public DbSet<Models.SuperStars> SuperStars { get; set; }

    }
}
