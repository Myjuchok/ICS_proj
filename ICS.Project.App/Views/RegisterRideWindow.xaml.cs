using System;
using System.Windows;
using ICS.Project.App.ViewModels.Commands;

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterRideWindow.xaml
    /// </summary>
    public partial class RegisterRideWindow : Window
    {
        public RegisterRideWindow()
        {
            InitializeComponent();
            DataContext = new WindowManagerVm();
        }

        private void OpenSelector(object sender, RoutedEventArgs e)
        {
            SelectorWindow newSelectorWindow = new SelectorWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
