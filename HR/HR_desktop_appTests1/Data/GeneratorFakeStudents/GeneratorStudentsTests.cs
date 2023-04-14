using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR_desktop_app.Data.GeneratorFakeStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_desktop_app.Data.GeneratorFakeStudents.Tests
{
    [TestClass()]
    public class GeneratorStudentsTests
    {
        [TestMethod()]
        [DataRow(5,5)]
        [DataRow(10, 10)]
        [DataRow(0, 0)]
        [DataRow(-1, 0)]
        public void GetStudentsTest_ShouldWork(int count, int expected)
        {

            //Arrenge

            //Act
            var actual = GeneratorStudents.GetStudents(count, null);

            //Assert
            Assert.AreEqual(expected, actual.Count);
        }
    }
}