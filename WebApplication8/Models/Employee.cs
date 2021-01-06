using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Remark { get; set; }

        public Movie Movie { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

        public SuperStars SuperStars { get; set; }
       
    }
}
