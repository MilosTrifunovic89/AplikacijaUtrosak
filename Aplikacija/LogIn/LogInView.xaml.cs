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

namespace Aplikacija.LogIn
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void OnLogInButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LogInViewModel logInViewModel)
            {
                if (String.IsNullOrEmpty(logInViewModel.FirstName) || String.IsNullOrEmpty(logInViewModel.Password))
                    MessageBox.Show("Unesi korisnicko ime ili sifru", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (logInViewModel.User == null)
                    MessageBox.Show("Korisnik se ne nalazi u bazi", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    MessageBox.Show("Prijava je uspela", "Prijava", MessageBoxButton.OK, MessageBoxImage.Information);
                    logInViewModel.LogInCommand.Execute(null);
                }
            }
        }

        private void OnQuitButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LogInViewModel logInViewModel)
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da napustite aplikaciju?", "IZLAZ", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    logInViewModel.QuitCommand.Execute(null);
            }
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
            else if (sender is PasswordBox)
                (sender as PasswordBox).SelectAll();
        }

        private void OnFormLoad_Event(object sender, RoutedEventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
