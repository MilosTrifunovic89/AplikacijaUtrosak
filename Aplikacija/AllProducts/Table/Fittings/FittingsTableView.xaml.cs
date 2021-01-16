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

namespace Aplikacija.AllProducts.Table.Fittings
{
    /// <summary>
    /// Interaction logic for FittingsView.xaml
    /// </summary>
    public partial class FittingsTableView : UserControl
    {
        public FittingsTableView()
        {
            InitializeComponent();
        }

        private void OnButtonClickInsertFitting_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is FittingsTableViewModel fittingsTableViewModel)
            {
                if (fittingsTableViewModel.SelectedFitting != null && fittingsTableViewModel.Number > 0)
                    fittingsTableViewModel.InsertFittingCommand.Execute(null);
                else if (fittingsTableViewModel.SelectedFitting == null)
                    MessageBox.Show("Odaberi okov");
                else if (fittingsTableViewModel.Number <= 0)
                    MessageBox.Show("Kolicina mora biti veca od 0");
            }
        }

        private void OnButtonClickRemoveFitting_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is FittingsTableViewModel fittingsTableViewModel)
            {
                if (fittingsTableViewModel.SelectedFittingToRemove != null)
                    fittingsTableViewModel.RemoveFittingCommand.Execute(null);
                else if (fittingsTableViewModel.SelectedFittingToRemove == null)
                    MessageBox.Show("Odaberi okov za uklanjanje");                
            }
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
            else if (sender is PasswordBox)
                (sender as PasswordBox).SelectAll();
        }
    }
}
