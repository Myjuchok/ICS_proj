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

namespace ICS.Project.App.Views
{
    /// <summary>
    /// Логика взаимодействия для EditVihicle.xaml
    /// </summary>
    public partial class EditVihicle : Window
    {
        public EditVihicle()
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
