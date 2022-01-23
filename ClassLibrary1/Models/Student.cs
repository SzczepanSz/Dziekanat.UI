using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziekanat.DAL.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public double PESEL { get; set; }
    }
}
