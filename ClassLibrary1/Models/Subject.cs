using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziekanat.DAL.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public string SubjectName { get; set; }
        public int Semester { get; set; }
        public string Lecturer { get; set; }
    }
}
