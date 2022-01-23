using System;
using System.Collections.Generic;
using Dziekanat.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Dziekanat.DAL
{
    public class DziekanatContext : DbContext , IDbContextFactory
    {
      //  private DbContextOptions<DziekanatContext> _options;
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }

        DziekanatContext _dziekanatContext;
        //public DziekanatContext() :
        //base()
        //{
        //    //this._options = new DbContextOptionsBuilder<DziekanatContext>()
        //    //                .UseInMemoryDatabase(databaseName: "Dziekanat")
        //    //                .Options;

        //}

        public DziekanatContext(DbContextOptions<DziekanatContext> options) :
        base(options)
        {
            //this._options = options;
            //new DbContextOptionsBuilder<DziekanatContext>()
            //                .UseInMemoryDatabase(databaseName: "Dziekanat")
            //                .Options;

        }

        public void SetContext(DbContextOptions<DziekanatContext> options)
        {
            _dziekanatContext = new DziekanatContext(options);

        }

   
        void IDbContextFactory.ADDStudent(Student student)
        {


            //using (var context = new DziekanatContext(_options))
            //{

            _dziekanatContext.Students.Add(student);
            _dziekanatContext.SaveChanges();
            //}
        }

        void IDbContextFactory.DELETEStudent(int idStudent)
        {
            //using (var context = new DziekanatContext(_options))
            //{
            _dziekanatContext.Attach(new Student { IdStudent = idStudent });
          //  _dziekanatContext.Students.Attach();
            _dziekanatContext.Students.Remove(new Student { IdStudent = idStudent});
            _dziekanatContext.SaveChanges();
          //  }        
        }

        List<Student> IDbContextFactory.GetAllStudents()
        {
         //   AddSomeStudents();
        //    using (var context = new DziekanatContext(_options))
        //    {
                return _dziekanatContext.Students.ToListAsync().Result; ;
         //   }
        }

        void IDbContextFactory.ADDShoolSubject(Subject shoolSubjects)
        {
            
            //   using (var context = new DziekanatContext(_options))
            //   {
            _dziekanatContext.Subjects.Add(shoolSubjects);
            _dziekanatContext.SaveChanges();
          //  }
        }

        void IDbContextFactory.DELETEShoolSubject(int idShoolSubject)
        {
         //   using (var context = new DziekanatContext(_options))
         //   {
                _dziekanatContext.Subjects.Remove(new Subject { IdSubject = idShoolSubject });
                _dziekanatContext.SaveChanges();
        //    }
        }

        List<Subject> IDbContextFactory.GetAllSubject()
        {
            //   using (var context = new DziekanatContext(_options))
            //   {
            return _dziekanatContext.Subjects.ToListAsync().Result; 
          //  }
        }

        public void AddSomeSubjects()
        {
            var storedList = new List<Subject>
            {
                    new Subject() { Lecturer = "Twoja Stara" },
                    new Subject() { Lecturer = "Moja Staara" },
                    new Subject() { Lecturer = "Staara" }
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
                    new Student() {  Name="Martin" },
                    new Student() { Name ="Scorsese" },
                    new Student() {  Name="Richi" }
            };
            foreach (var game in storedList)
            {
                _dziekanatContext.Add(game);
                _dziekanatContext.SaveChanges();
            }
        }
    }
}