using System;
using System.Windows;
using ICS.Project.App.ViewModels.Commands;
using ICS.Project.App.Views;

namespace ICS.Project.App
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserDetailWindow.xaml
    /// </summary>
    public partial class ChangeUserDetailWindow : Window
    {
        public ChangeUserDetailWindow()
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
    }
}
