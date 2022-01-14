using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.ViewModels
{
    class DatabaseSourceEventArgs:EventArgs
    {
        private string databaseSource;

        public DatabaseSourceEventArgs(string databaseSource)
        {
            this.DatabaseSource = databaseSource;
        }

        public string DatabaseSource { get => databaseSource; set => databaseSource = value; }

    }
}
