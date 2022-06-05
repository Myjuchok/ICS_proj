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
using ICS.Project.App.ViewModels;
using ICS.Project.App.ViewModels.Commands;

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();

        }

        private void OpenSelector(object sender, RoutedEventArgs e)
        {
            SelectorWindow newSelectorWindow = new SelectorWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void OpenCreate(object sender, RoutedEventArgs e)
        {
            CreateUserWindow newSelectorWindow = new CreateUserWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
        }

        private void AddNewV(object sender, RoutedEventArgs e)
        {
            ChangeUserDetailWindow newSelectorWindow = new ChangeUserDetailWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
