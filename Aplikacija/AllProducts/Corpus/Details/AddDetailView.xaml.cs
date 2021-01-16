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

namespace Aplikacija.AllProducts.Corpus.Details
{
    /// <summary>
    /// Interaction logic for AddDetailView.xaml
    /// </summary>
    public partial class AddDetailView : UserControl
    {
        public AddDetailView()
        {
            InitializeComponent();
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
        }

        private void OnInsertDetailButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is AddDetailViewModel detailViewModel)
            {
                if (detailViewModel.SelectedDetail == null)
                    MessageBox.Show("Odaberi detalj za dodavanje");
                else if (detailViewModel.Number < 1)
                    MessageBox.Show("Broj komada ne moze biti manji od 1");
                else
                    detailViewModel.AddDetailCommand.Execute(null);
            }
        }

        private void OnRemoveDetailButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is AddDetailViewModel detailViewModel)
            {
                if (detailViewModel.DetailToRemove == null)
                    MessageBox.Show("Odaberi detalj za uklanjanje");
                else
                    detailViewModel.RemoveDetailCommand.Execute(null);
            }
        }
    }
}
