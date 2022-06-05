using System;
using System.Windows;
using ICS.Project.App.ViewModels.Commands;

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectorWindow.xaml
    /// </summary>
    public partial class SelectorWindow : Window
    {
        public SelectorWindow()
        {
            InitializeComponent();
        }

        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            ProfileWindow newSelectorWindow = new ProfileWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void OpenRegister(object sender, RoutedEventArgs e)
        {
            RegisterRideWindow newSelectorWindow = new RegisterRideWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void OpenRides(object sender, RoutedEventArgs e)
        {
            MyRides newSelectorWindow = new MyRides();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
