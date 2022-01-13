using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Repositories;
using Vizsgaremek.Models;
using static Vizsgaremek.Models.DatabaseSource;

namespace Vizsgaremek.ViewModels
{
    public class DataBaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        private string displayedDatabaseSource;
        private DbSource dbSource;

        DatabaseSources repoDatabaseSouerces;

        public ObservableCollection<string> DisplayedDatabaseSources
        {
            get => displayedDatabaseSources;
        }
        public string SelectedDatabaseSource
        {
            get => selectedDatabaseSource;
            set
            {
                selectedDatabaseSource = value;
                displayedDatabaseSource = DisplayedDatabaseSource;
                dbSource = DbSource;
            }
        }

        public DbSource DbSource
        {
            get
            {
                // TDD fejlesztés
                // return DbSource.NONE;
                if (selectedDatabaseSource == "localhost")
                    return DbSource.LOCALHOST;
                else if (selectedDatabaseSource == "devops")
                    return DbSource.DEVOPS;
                return DbSource.NONE;
            }
        }

        public string DisplayedDatabaseSource
        {
            get
            {
                switch (dbSource)
                {
                    case DbSource.DEVOPS:
                        return "devops adatforrás.";
                        break;
                    case DbSource.LOCALHOST:
                        return "localhost adatforrás.";
                    case DbSource.NONE:
                        return "beépített teszt adatok.";
                    default:
                        return "";
                }
            }

        }

        public DataBaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSources();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSouerces.GetAllDatabaseSources());
            SelectedDatabaseSource = "localhost";
        }
    }
}
