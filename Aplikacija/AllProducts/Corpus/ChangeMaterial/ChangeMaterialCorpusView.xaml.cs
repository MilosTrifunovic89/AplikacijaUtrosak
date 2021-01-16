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

namespace Aplikacija.AllProducts.Corpus.ChangeMaterial
{
    /// <summary>
    /// Interaction logic for ChangeMaterialCorpusView.xaml
    /// </summary>
    public partial class ChangeMaterialCorpusView : UserControl
    {
        public ChangeMaterialCorpusView()
        {
            InitializeComponent();
        }

        private void OnChangeMaterialButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is ChangeMaterialCorpusViewModel changeMaterialCorpusViewModel)
            {
                if (changeMaterialCorpusViewModel.SelectedDetail == null)
                    MessageBox.Show("Odaberi detalj kome menjas materijal");
                else if (changeMaterialCorpusViewModel.SelectedMaterial == null)
                    MessageBox.Show("Odaberi novi materijal");
                else if (changeMaterialCorpusViewModel.SelectedMaterial.MaterialID == changeMaterialCorpusViewModel.SelectedDetail.Material.MaterialID)
                    MessageBox.Show("Odabrani materijal se vec nalazi na detalju");
                else
                    changeMaterialCorpusViewModel.ChangeMaterialCommand.Execute(null);
            }
        }
    }
}
