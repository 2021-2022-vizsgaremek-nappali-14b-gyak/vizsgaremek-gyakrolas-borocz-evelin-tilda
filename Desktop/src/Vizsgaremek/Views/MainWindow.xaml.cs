using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Vizsgaremek.Views.Navigation;
using Vizsgaremek.Views.Pages;
using Vizsgaremek.ViewModels;

using System.Globalization;
using System.Threading;

namespace Vizsgaremek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        private DatabaseSourceViewModel databaseSourceViewModel;

        private ResourceDictionary dict;

        public MainWindow()
        {
            // Különböző ablakok adatai
            mainWindowViewModel = new MainWindowViewModel();
            databaseSourceViewModel = new DatabaseSourceViewModel();
            mainWindowViewModel.SelectedSource = databaseSourceViewModel.DisplayedDatabaseSource;


            // Feliratkozunk az eseményre. Ha változik az adat az adott osztályba tudni fogunk róla!
            databaseSourceViewModel.ChangeDatabaseSource += DatabaseSourceViewModel_ChangeDatabaseSource;

            dict = new ResourceDictionary();
            CultureInfo.CurrentCulture = new CultureInfo("en-En");
            SetLanguageDictionary();

            InitializeComponent();
            // A MainWindow ablakban megjelenő adatok a MainWindowViewModel-ben vannak
            this.DataContext = mainWindowViewModel;
            // Statikus osztály a Navigate
            // Eltárolja a nyitó ablakt, hogy azon tudjuk módosítani a "page"-ket
            Navigate.mainWindow = this;
            // Létrehozzuk a nyitó "UsuerControl" (WelcomPage)
            WelcomePage welcomePage = new WelcomePage();
            // Megjelnítjük a WelcomePage-t
            Navigate.Navigation(welcomePage);
        }

        private void DatabaseSourceViewModel_ChangeDatabaseSource(object sender, EventArgs e)
        {
            DatabaseSourceEventArg dsea = (DatabaseSourceEventArg) e;
            mainWindowViewModel.SelectedSource = dsea.DatabaseSource;
        }

        /// <summary>
        /// ListView elemen bal egér gomb fel lett engedve
        /// </summary>
        /// <param name="sender">ListView amin megnyomtuk a bal egér gombot</param>
        /// <param name="e"></param>
        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvMenu = sender as ListView;
            ListViewItem lvMenuItem = lvMenu.SelectedItem as ListViewItem;
            //ListViewItem lvMenuItem = (ListViewItem) lvMenu.SelectedItem;

            if (lvMenuItem != null)
            {
                // x:Name tulajdonságot vizsgáljuk
                switch (lvMenuItem.Name)
                {
                    case "lviExit":
                        Close();
                        break;
                    case "lviDatabaseSouceSelection":
                        DatabaseSourcePage databaseSourcePage = new DatabaseSourcePage(databaseSourceViewModel);
                        Navigate.Navigation(databaseSourcePage);
                        break;
                    case "lviProgramVersion":
                        ProgramInfo programVersion = new ProgramInfo();
                        Navigate.Navigation(programVersion);
                        break;
                }                
            }
        }

        private void SetLanguageDictionary()
        {

            switch (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;

  /*              case "fr":
                    dict.Source = new Uri("..\\Resources\\FR\\StringResources.xaml", UriKind.Relative);
                    break;*/
                case "hu":
                    dict.Source = new Uri("..\\Resources\\HU\\StringResources.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}

