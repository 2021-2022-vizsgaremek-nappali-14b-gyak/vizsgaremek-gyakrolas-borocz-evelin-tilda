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
        private DbSource dbSource;
        DatabaseSource databaseSource;
        private string displayedDatabaseSource;

        DatabaseSources repoDataBaseSources;

        public ObservableCollection<string> DisplayedDatabaseSource { get => displayedDatabaseSources; }
        public string SelectedDatabaseSource { get => selectedDatabaseSource; set => selectedDatabaseSource = value; }
        public DbSource DbSource
        {
            get
            {
                //TDD fejlesztés
                //return DbSource.NONE;
                if (selectedDatabaseSource == "loacalhost")
                {
                    return DbSource.LOCALHOST;
                }
                else if (selectedDatabaseSource=="devops")
                {
                    return DbSource.DEVOPS;
                }
                return DbSource.NONE;
            }
        }

        public string DisplayedDatabaseSource { 
            get {
                switch (dbSource)
                {
                    case DbSource.DEVOPS:
                        return "devops adatforrás";
                        break;
                    case DbSource.LOCALHOST:
                        return "localhost adatforrás";
                        break;
                    case DbSource.NONE:
                        return "beépített adatforrás";
                        break;
                    default:
                        return "";
                }
            } 
        }

        public DataBaseSourceViewModel()
        {
            this.repoDataBaseSources = new DatabaseSources();
            this.displayedDatabaseSources = new ObservableCollection<string>(repoDataBaseSources.GetAllDatabaseSources());
        }
    }
}
