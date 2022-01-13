using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Models;
using Vizsgaremek.ViewModels;


namespace Vizsgaremek.ViewModels.Tests
{
    [TestClass()]
    public class DatabaseSourceViewModelTests
    {
        [TestMethod()]
        public void DatabaseSourceViewModelTestLocalhost()
        {
            DataBaseSourceViewModel databaseSourceViewModel = new DataBaseSourceViewModel();
            // Felhasználó "rákkattintott a "localhost" szóra
            databaseSourceViewModel.SelectedDatabaseSource = "localhost";
            DbSource expectedDbSource = DbSource.LOCALHOST;

            DbSource actualDbSource = databaseSourceViewModel.DbSource;

            Assert.AreEqual(expectedDbSource, actualDbSource, "A kiválasztott adatbázis a 'localhost', de nem váltott át DbSource.LOCALHOST-ra");
        }

        [TestMethod()]
        public void DatabaseSourceViewModelTestDevops()
        {
            DataBaseSourceViewModel databaseSourceViewModel = new DataBaseSourceViewModel();
            // Felhasználó "rákkattintott a "localhost" szóra
            databaseSourceViewModel.SelectedDatabaseSource = "devops";
            DbSource expectedDbSource = DbSource.DEVOPS;

            DbSource actualDbSource = databaseSourceViewModel.DbSource;

            Assert.AreEqual(expectedDbSource, actualDbSource, "A kiválasztott adatbázis a 'devops', de nem váltott át DbSource.DEVOPS-ra");
        }

        [TestMethod()]
        public void DatabaseSourceViewModelTestNone()
        {
            DataBaseSourceViewModel databaseSourceViewModel = new DataBaseSourceViewModel();
            // Felhasználó "rákkattintott a "localhost" szóra
            databaseSourceViewModel.SelectedDatabaseSource = "";
            DbSource expectedDbSource = DbSource.NONE;

            DbSource actualDbSource = databaseSourceViewModel.DbSource;

            Assert.AreEqual(expectedDbSource, actualDbSource, "A kiválasztott adatbázis a '', de nem váltott át DbSource.NONE-ra");
        }
    }
}