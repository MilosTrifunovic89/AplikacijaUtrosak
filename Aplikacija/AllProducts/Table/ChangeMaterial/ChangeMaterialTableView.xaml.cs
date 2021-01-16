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

namespace Aplikacija.AllProducts.Table.ChangeMaterial
{
    /// <summary>
    /// Interaction logic for ChangeMaterialTableView.xaml
    /// </summary>
    public partial class ChangeMaterialTableView : UserControl
    {
        public ChangeMaterialTableView()
        {
            InitializeComponent();
        }

        private void OnChangeMaterialButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is ChangeMaterialTableViewModel changeMaterialTableViewModel)
            {
                if (changeMaterialTableViewModel.SelectedDetail == null)
                    MessageBox.Show("Odaberi detalj kome menjas materijal");
                else if (changeMaterialTableViewModel.SelectedMaterial == null)
                    MessageBox.Show("Odaberi novi materijal");
                else if (changeMaterialTableViewModel.SelectedMaterial .MaterialID== changeMaterialTableViewModel.SelectedDetail.Material.MaterialID)
                    MessageBox.Show("Odabrani materijal se vec nalazi na detalju");
                else
                    changeMaterialTableViewModel.ChangeMaterialCommand.Execute(null);
            }
        }
    }
}
