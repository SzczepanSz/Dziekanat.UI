using Dziekanat.DAL;
using Dziekanat.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dziekanat.Controller

{
    public class DziekanatController
    {

        IDbContextFactory _dbcontextfactory;
        InputVerifier _inputVerifier;
        public DziekanatController()
        {
            var options = new DbContextOptionsBuilder<DziekanatContext>()
                           .UseInMemoryDatabase(databaseName: "Dziekanat")
                           .Options;

            this._dbcontextfactory = new DziekanatContext(options);
            _dbcontextfactory.SetContext(options);
            _dbcontextfactory.AddSomeStudents();
            _dbcontextfactory.AddSomeSubjects();

            _inputVerifier = new InputVerifier();
        }
        
        public List<Student> GetAllStudents()
        {
            return _dbcontextfactory.GetAllStudents();
        }

        public void AddStudent(Student student)
        {
            _dbcontextfactory.ADDStudent(student);
        }

        public void DeleteStudent(int idStudent)
        {
            _dbcontextfactory.DELETEStudent(idStudent);
        }

        public List<Subject> GetAllSubjects()
        {
            return _dbcontextfactory.GetAllSubject();
        }

        public void AddSubject(Subject subject)
        {
            _dbcontextfactory.ADDShoolSubject(subject);
        }

        public void DeleteSubjects(int idSubjects)
        {
            _dbcontextfactory.DELETEShoolSubject(idSubjects);
        }

        public List<Student> AddEmptyRowStudent()
        {
            var tempList = _dbcontextfactory.GetAllStudents();
            tempList.Add(new Student());
            return tempList; 
        }
        public List<Subject> AddEmptyRowSubject()
        {
            var tempList = _dbcontextfactory.GetAllSubject();
            tempList.Add(new Subject());
            return tempList;
        }


        public bool IsString(string text)
        {
            return text != null ? _inputVerifier.IsString(text) : false;
        }

        public bool IsLongString(string text)
        {
            return _inputVerifier.IsLongString(text);

        }

        public bool IsPESEL(string text)
        {
            return _inputVerifier.IsPESEL(text);
        }

        public bool IsSemester(string text)
        {
            return _inputVerifier.IsSemester(text);
        }
    }
}
