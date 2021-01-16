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

namespace Aplikacija.AllProducts.Corpus.Main
{
    /// <summary>
    /// Interaction logic for CorpusView.xaml
    /// </summary>
    public partial class CorpusView : UserControl
    {
        public CorpusView()
        {
            InitializeComponent();
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
        }

        private void OnButtonClickCreateCorpus_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (String.IsNullOrWhiteSpace(corpusViewModel.CorpusName) || corpusViewModel.Height == 0 || corpusViewModel.Width == 0 || corpusViewModel.Depth == 0
                    || corpusViewModel.LegHeight == 0)
                {
                    MessageBox.Show("Unesi dimenzije korpusa");
                    return;
                }

                corpusViewModel.CreateCommand.Execute(null);

                if (corpusViewModel.Corpus != null)
                    MessageBox.Show($"Kreiran je {corpusViewModel.Corpus.ElementName} dimenzija {corpusViewModel.Corpus.Width}/{corpusViewModel.Corpus.Depth}/" +
                        $"{corpusViewModel.Corpus.Height}h");
            }
        }

        private void OnButtonClickChangeMaterial_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (corpusViewModel.Corpus == null)
                    MessageBox.Show("Najpre kreiraj korpus");
                else
                    corpusViewModel.ChangeMaterialCommand.Execute(null);
            }
        }

        private void OnButtonClickEdgeTape_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (corpusViewModel.Corpus == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    corpusViewModel.EdgeTapeCommand.Execute(null);
            }
        }

        private void OnButtonClickFittings_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (corpusViewModel.Corpus == null)
                    MessageBox.Show("Najpre kreiraj korpus");
                else
                    corpusViewModel.FittingsCommand.Execute(null);
            }
        }

        private void OnButtonClickGetSpecification_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (corpusViewModel.Corpus == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    corpusViewModel.GetSpecificationCommand.Execute(null);
            }
        }

        private void OnButtonClickResetCommand_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da resetujete sve podatke?", "RESET", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    corpusViewModel.ResetCommand.Execute(null);
            }
        }

        private void OnButtonInsertIntoBaseClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                corpusViewModel.InsertIntoBaseCommand.Execute(null);
                MessageBox.Show("Element je uspesno unet u bazu");
            }
        }

        private void OnButtonClickAddDetail_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CorpusViewModel corpusViewModel)
            {
                if (corpusViewModel.Corpus == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    corpusViewModel.AddDetailCommand.Execute(null);
            }
        }
    }
}
