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

namespace Aplikacija.AllProducts.Table.EdgeTapes
{
    /// <summary>
    /// Interaction logic for EdgeTapeTableView.xaml
    /// </summary>
    public partial class EdgeTapeTableView : UserControl
    {
        public EdgeTapeTableView()
        {
            InitializeComponent();
        }

        private void OnSetEdgeTapeCommand_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeTableViewModel edgeTapeTableViewModel)
            {
                if (edgeTapeTableViewModel.SelectedDetail == null)
                    MessageBox.Show("Odaberi detalj za kantovanje");
                else if (edgeTapeTableViewModel.SelectedEdgeTapeOne == null && edgeTapeTableViewModel.SelectedEdgeTapeTwo == null
                    && edgeTapeTableViewModel.SelectedEdgeTapeThree == null && edgeTapeTableViewModel.SelectedEdgeTapeFour == null)
                    MessageBox.Show("Odaberi traku kojom kantujes");
                else if (edgeTapeTableViewModel.SelectedDetail.Material.Thickness <= 8)
                    MessageBox.Show("Ne moze da se kantuje materijal tanji od 8 mm");
                else
                    edgeTapeTableViewModel.SetEdgeTape.Execute(null);

            }
        }

        private void OnDeleteAllEdgeTapesFromElement_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeTableViewModel edgeTapeTableViewModel)
            {
                edgeTapeTableViewModel.ResetAll.Execute(null);
                MessageBox.Show("Izbrisana su sva kantovanja sa elementa");
            }
        }

        private void OnDeleteEdgeTapesFromDetail_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EdgeTapeTableViewModel edgeTapeTableViewModel)
            {
                if (edgeTapeTableViewModel.SelectedDetail != null)
                {
                    edgeTapeTableViewModel.ResetFromDetail.Execute(null);
                    MessageBox.Show("Izbrisana su sva kantovanja sa detalja");
                }
                else
                    MessageBox.Show("Odaberi detalj sa koga uklanjas kantovanja");
            }
        }
    }
}
