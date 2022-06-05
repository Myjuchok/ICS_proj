using System;
using System.Windows;
using ICS.Project.App.ViewModels.Commands;

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
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

        private void OpenProfile_UserCreated(object sender, RoutedEventArgs e)
        {
            ProfileWindow newSelectorWindow = new ProfileWindow();
            newSelectorWindow.Owner = Application.Current.MainWindow;
            newSelectorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newSelectorWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
