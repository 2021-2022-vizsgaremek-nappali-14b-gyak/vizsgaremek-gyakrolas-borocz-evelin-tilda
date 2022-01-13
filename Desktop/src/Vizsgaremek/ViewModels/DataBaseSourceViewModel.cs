using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Repositories;

namespace Vizsgaremek.ViewModels
{
    class DataBaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        DatabaseSources repoDataBaseSources;

        public ObservableCollection<string> DisplayedDatabaseSource { get => displayedDatabaseSources; }
        public string SelectedDatabaseSource { get => selectedDatabaseSource; set => selectedDatabaseSource = value; }

        public DataBaseSourceViewModel()
        {
            this.repoDataBaseSources = new DatabaseSources();
            this.displayedDatabaseSources = new ObservableCollection<string>(repoDataBaseSources.GetAllDatabaseSources());
        }
    }
}
