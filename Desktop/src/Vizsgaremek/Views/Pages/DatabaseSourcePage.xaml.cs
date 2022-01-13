﻿using System;
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
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Views.Pages
{
    /// <summary>
    /// Interaction logic for DatabaseSourcePage.xaml
    /// </summary>
    public partial class DatabaseSourcePage : UserControl
    {
        DataBaseSourceViewModel dataBaseSourceViewModel;
        public DatabaseSourcePage()
        {
            dataBaseSourceViewModel = new DataBaseSourceViewModel();
            InitializeComponent();
            this.DataContext = dataBaseSourceViewModel;
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            Navigate.Navigation(welcomePage);
        }
    }
}
