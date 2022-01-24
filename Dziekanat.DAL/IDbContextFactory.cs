using Dziekanat.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Dziekanat.DAL
{
    public interface IDbContextFactory
    {
        public void SetContext(DbContextOptions<DziekanatContext> options);
        public void ADDStudent(Student student);
        public void DELETEStudent(int idStudent);
        public List<Student> GetAllStudents();

        public void ADDShoolSubject(Subject shoolSubjects);
        public void DELETEShoolSubject(int idShoolSubject);
        public List<Subject> GetAllSubject();

        public void AddSomeSubjects();
        public void AddSomeStudents();
    }
}