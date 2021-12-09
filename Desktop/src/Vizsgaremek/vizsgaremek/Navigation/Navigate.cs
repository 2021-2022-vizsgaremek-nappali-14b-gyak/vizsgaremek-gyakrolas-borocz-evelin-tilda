using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vizsgaremek.Navigation
{
    public static class Navigate
    {
        //eltároljuk a MainWindow-t hogy tudjunk váltani ablakot
        public static MainWindow mainWindow;
        /// <summary>
        /// egy új ablakra vált</summary>
        /// <param name="userControl"></param>erre az ablakra váltunk
        public static void Navigation(UserControl userControl)
        {
            mainWindow.PageContent.Children.Clear();
            mainWindow.PageContent.Children.Add(userControl);
        }
    }
}
