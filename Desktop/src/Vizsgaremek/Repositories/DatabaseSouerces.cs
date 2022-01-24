using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Repositories
{
    class DatabaseSouerces
    {
        private List<string> databaseSourcesItems;

        public DatabaseSouerces()
        {
            string storedSelectedSource = Properties.Settings.Default.storedDataSource;
            
            if (storedSelectedSource == "test")
            {
                databaseSourcesItems = new List<string>();
                databaseSourcesItems.Add("localhost");
                databaseSourcesItems.Add("devops");
            }
            else
            {
                databaseSourcesItems = new List<string>();
                ApplicationConfigurations appConfigRepo = new ApplicationConfigurations();
                Dictionary<string, string> allPossibleDatabaseSources = new Dictionary<string, string>();
                allPossibleDatabaseSources = appConfigRepo.DatabaseSources;
                foreach (KeyValuePair<string,string> possibleDatabaseSource in allPossibleDatabaseSources)
                {
                    string item = possibleDatabaseSource.Key;
                    databaseSourcesItems.Add(item);
                }
            }
        }

        public List<string> GetAllDatabaseSources()
        {
            return databaseSourcesItems;
        }
    }

}

