using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Vizsgaremek.Repositories;
using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    public class DatabaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        private string displayedDatabaseSource;
        private DbSource dbSource;

        DatabaseSouerces repoDatabaseSouerces;

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
                OnDatabaseSourceChange();
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
                switch(dbSource)
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

        // Erre az eseményre iratkozhat fel egy másik osztály
        public event EventHandler ChangeDatabaseSource;

        public DatabaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSouerces();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSouerces.GetAllDatabaseSources());
            SelectedDatabaseSource = "localhost";
        }

        // Esemény kiváltása (raise)
        protected void OnDatabaseSourceChange()
        {
            // Argumentumba belepakoljuk az üzenetet
            DatabaseSourceEventArg dsea = new DatabaseSourceEventArg(DisplayedDatabaseSource);
            // Ha van esemény akkor meghívjük a feliratkozott osztályokat;
            if (ChangeDatabaseSource != null)
                ChangeDatabaseSource.Invoke(this, dsea);
        }

    }
}
