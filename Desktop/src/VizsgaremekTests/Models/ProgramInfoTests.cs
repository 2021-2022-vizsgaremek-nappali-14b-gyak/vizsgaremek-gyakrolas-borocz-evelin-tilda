using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Models.Tests
{
    [TestClass()]
    public class ProgramInfoTests
    {
        [TestMethod()]
        public void ProgramInfoTestVersion()
        {
            // arrange
            ProgramInfo programInfo = new ProgramInfo();
            Version expected = new Version(0, 0, 3, 0);

            // act
            Version actual = programInfo.Version;

            // assert
            Assert.AreEqual(expected, actual, "Version is not 0.0.3.0");
        }

        [TestMethod()]
        public void ProgramInfoTestTitle()
        {
            //title desc company
            //title
            //arrange
            ProgramInfo programInfo = new ProgramInfo();
            string expected = new string("Vizsgaremek");
            //act
            string actual = programInfo.Title;
            //assert
            Assert.AreEqual(expected, actual, "Title is not Vizsgaremek");

        }

        [TestMethod()]
        public void ProgramInfoTestDescription()
        {
            //title desc company
            //description
            //arrange
            ProgramInfo programInfo = new ProgramInfo();
            string expected = new string("A program mvvm része programozás alatt");
            //act
            string actual = programInfo.Description;
            //assert
            Assert.AreEqual(expected, actual, "Desc is not A program mvvm része programozás alatt");

        }

        [TestMethod()]
        public void ProgramInfoTestCompany()
        {
            //title desc company
            //company
            //arrange
            ProgramInfo programInfo = new ProgramInfo();
            string expected = new string("Vasvári");
            //act
            string actual = programInfo.Company;
            //assert
            Assert.AreEqual(expected, actual, "Company is not Vasvári");

        }
    }
}