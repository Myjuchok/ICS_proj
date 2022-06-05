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
using System.Windows.Shapes;
using ICS.Project.App.ViewModels.Commands;
using ICS.Project.App.ViewModels;

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для MyRides.xaml
    /// </summary>
    public partial class MyRides : Window
    {
        public MyRides()
        {
            InitializeComponent();
        }
        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            SelectorWindow newSelectorWindow = new SelectorWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
