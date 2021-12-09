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
using vizsgaremek.Navigation;
using vizsgaremek.Pages;

namespace vizsgaremek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Statikus osztály a Navigate
            // Eltárolja a nyitó ablakt, hogy azon tudjuk módosítani a "page"-ket
            Navigate.mainWindow = this;
            // Létrehozzuk a nyitó "UsuerControl" (WelcomPage)
            WelcomePage welcomePage = new WelcomePage();
            // Megjelnítjük a WelcomePage-t
            Navigate.Navigation(welcomePage);

        }
        /// <summary>
        /// Listview elem bal egér gomb fel lett engedve
        /// </summary>
        /// <param name="sender"></param>amin megnyomtuk a bal egér gombot
        /// <param name="e"></param>
        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvMenu = sender as ListView;
            ListViewItem lvMenuItem = lvMenu.SelectedItem as ListViewItem;
            //vagy as helyett típuskényszerítés
            if (lvMenuItem!=null)
            {
                switch (lvMenuItem.Name)
                {
                    case "lvIExit":
                        Close();
                        break;
                }
            }
        }
    }
}
