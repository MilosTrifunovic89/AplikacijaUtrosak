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

namespace Aplikacija.AllProducts.Corpus.EdgeTapes
{
    /// <summary>
    /// Interaction logic for EdgeTapeCorpusView.xaml
    /// </summary>
    public partial class EdgeTapeCorpusView : UserControl
    {
        public EdgeTapeCorpusView()
        {
            InitializeComponent();
        }

        private void OnSetEdgeTapeCommand_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeCorpusViewModel edgeTapeCorpusViewModel)
            {
                if (edgeTapeCorpusViewModel.SelectedDetail == null)
                    MessageBox.Show("Odaberi detalj za kantovanje");
                else if (edgeTapeCorpusViewModel.SelectedEdgeTapeOne == null && edgeTapeCorpusViewModel.SelectedEdgeTapeTwo == null
                    && edgeTapeCorpusViewModel.SelectedEdgeTapeThree == null && edgeTapeCorpusViewModel.SelectedEdgeTapeFour == null)
                    MessageBox.Show("Odaberi traku kojom kantujes");
                else if (edgeTapeCorpusViewModel.SelectedDetail.Material.Thickness <= 8)
                    MessageBox.Show("Ne moze da se kantuje materijal tanji od 8 mm");
                else
                    edgeTapeCorpusViewModel.SetEdgeTape.Execute(null);

            }
        }

        private void OnDeleteAllEdgeTapesFromElement_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeCorpusViewModel edgeTapeCorpusViewModel)
            {
                edgeTapeCorpusViewModel.ResetAll.Execute(null);
                MessageBox.Show("Izbrisana su sva kantovanja sa elementa");
            }
        }

        private void OnDeleteEdgeTapesFromDetail_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeCorpusViewModel edgeTapeCorpusViewModel)
            {
                if (edgeTapeCorpusViewModel.SelectedDetail != null)
                {
                    edgeTapeCorpusViewModel.ResetFromDetail.Execute(null);
                    MessageBox.Show("Izbrisana su sva kantovanja sa detalja");
                }
                else
                    MessageBox.Show("Odaberi detalj sa koga uklanjas kantovanja");
            }
        }
    }
}
