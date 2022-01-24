using System;
using System.Collections.Generic;
using Dziekanat.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Dziekanat.DAL
{
    public class DziekanatContext : DbContext , IDbContextFactory
    {
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }

        DziekanatContext _dziekanatContext;
      

        public DziekanatContext(DbContextOptions<DziekanatContext> options) :
        base(options)
        {
               
        }

        public void SetContext(DbContextOptions<DziekanatContext> options)
        {
            _dziekanatContext = new DziekanatContext(options);

        }

   
        void IDbContextFactory.ADDStudent(Student student)
        {
            _dziekanatContext.Students.Add(student);
            _dziekanatContext.SaveChanges();
        }

        void IDbContextFactory.DELETEStudent(int idStudent)
        {
           
            _dziekanatContext.Attach(new Student { IdStudent = idStudent });
            _dziekanatContext.Students.Remove(new Student { IdStudent = idStudent});
            _dziekanatContext.SaveChanges();
        }

        List<Student> IDbContextFactory.GetAllStudents()
        {
                return _dziekanatContext.Students.ToListAsync().Result; ;
        }

        void IDbContextFactory.ADDShoolSubject(Subject shoolSubjects)
        {
            _dziekanatContext.Subjects.Add(shoolSubjects);
            _dziekanatContext.SaveChanges();
        }

        void IDbContextFactory.DELETEShoolSubject(int idShoolSubject)
        {
                _dziekanatContext.Subjects.Remove(new Subject { IdSubject = idShoolSubject });
                _dziekanatContext.SaveChanges();
        }

        List<Subject> IDbContextFactory.GetAllSubject()
        {
            return _dziekanatContext.Subjects.ToListAsync().Result; 
        }

        public void AddSomeSubjects()
        {
            var storedList = new List<Subject>
            {
                    new Subject() { Lecturer = "Przemysław Martyniuk", SubjectName = "OOP" ,Semester = 6  },
                    new Subject() { Lecturer = "Kamil Budzisz" , SubjectName = "CNC MAchining",Semester = 3},
                    new Subject() { Lecturer = "Olek Staszkin" , SubjectName = "Chemistry", Semester = 2}
            };


            foreach (var game in storedList)
            {
                _dziekanatContext.Add(game);
                _dziekanatContext.SaveChanges();
            }
        }

        public void AddSomeStudents()
        {
            var storedList = new List<Student>
            {
                    new Student() {  Name="Martin" , SurName ="Ricki", PESEL = 85432305839},
                    new Student() { Name ="Scorsese", SurName = "Don" , PESEL = 75432305839},
                    new Student() {  Name="Richi" , SurName = "Kojote", PESEL= 65432305839} 
            };
            foreach (var game in storedList)
            {
                _dziekanatContext.Add(game);
                _dziekanatContext.SaveChanges();
            }
        }
    }
}