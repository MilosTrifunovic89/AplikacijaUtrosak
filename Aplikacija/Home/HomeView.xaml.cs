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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikacija.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void OnQuitButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is HomeViewModel homeViewModel)
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da napustite aplikaciju?", "IZLAZ", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    homeViewModel.QuitCommand.Execute(null);
            }
        }

        private void OnLogOutButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is HomeViewModel homeViewModel)
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da promenite operatera?", "IZLAZ", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    homeViewModel.LogOutCommand.Execute(null);
            }
        }
    }
}
