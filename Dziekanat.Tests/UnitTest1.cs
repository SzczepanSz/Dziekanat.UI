using NUnit.Framework;
using Dziekanat.Controller;
using Dziekanat.DAL.Models;
using System.Linq;

namespace Dziekanat.Tests
{
    public class Tests
    {
        DziekanatController dc;
           [SetUp]
        public void Setup()
        {
             dc= new DziekanatController();
        }

        [Test]
        public void Test1()
        {
           var res =  dc.IsString("TestWord");
           Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var res = dc.IsString("132");
            Assert.IsFalse(res);
        }

        [Test]
        public void Test3()
        {
            var res = dc.IsString(string.Empty);
            Assert.IsFalse(res);
        }

        [Test]
        public void Test4()
        {
             var res = dc.AddEmptyRowStudent();
             Assert.AreSame( new Student() { IdStudent = 0, Name = null, PESEL = 0, SurName = null },  res.Last());
        }





    }
}