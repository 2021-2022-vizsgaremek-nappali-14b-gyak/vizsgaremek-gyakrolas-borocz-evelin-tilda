using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vizsgaremk.Navigation
{
    public class Navigation
    {
        private static MainWindow mainWindow;
        public static void Navigate(UserControl userControl)
        {
            mainWindow.PageContent.Children.Clear();
            mainWindow.PageContent.Children.Add(userControl);
        }
    }
}
