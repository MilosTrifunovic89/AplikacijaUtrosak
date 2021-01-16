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

namespace Aplikacija.AllProducts.Corpus.Fittings
{
    /// <summary>
    /// Interaction logic for FittingsCorpusView.xaml
    /// </summary>
    public partial class FittingsCorpusView : UserControl
    {
        public FittingsCorpusView()
        {
            InitializeComponent();
        }

        private void OnButtonClickInsertFitting_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is FittingsCorpusViewModel fittingsCorpusViewModel)
            {
                if (fittingsCorpusViewModel.SelectedFitting != null && fittingsCorpusViewModel.Number > 0)
                    fittingsCorpusViewModel.InsertFittingCommand.Execute(null);
                else if (fittingsCorpusViewModel.SelectedFitting == null)
                    MessageBox.Show("Odaberi okov");
                else if (fittingsCorpusViewModel.Number <= 0)
                    MessageBox.Show("Kolicina mora biti veca od 0");
            }
        }

        private void OnButtonClickRemoveFitting_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is FittingsCorpusViewModel fittingsCorpusViewModel)
            {
                if (fittingsCorpusViewModel.SelectedFittingToRemove != null)
                    fittingsCorpusViewModel.RemoveFittingCommand.Execute(null);
                else if (fittingsCorpusViewModel.SelectedFittingToRemove == null)
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

        //private void OnPressEnter_Event(object sender, KeyEventArgs e)
        //{
        //    if (this.DataContext is FittingsCorpusViewModel fittingsCorpusViewModel)
        //    {
        //        if(e.Key==System.Windows.Input.Key.Enter)
        //        {
        //            if (fittingsCorpusViewModel.SelectedFitting != null && fittingsCorpusViewModel.Number > 0)
        //                fittingsCorpusViewModel.InsertFittingCommand.Execute(null);
        //            else if (fittingsCorpusViewModel.SelectedFitting == null)
        //                MessageBox.Show("Odaberi okov");
        //            else if (fittingsCorpusViewModel.Number <= 0)
        //                MessageBox.Show("Kolicina mora biti veca od 0");
        //        }
        //    }
        //}
    }
}
