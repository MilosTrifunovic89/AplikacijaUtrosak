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

namespace Aplikacija.MiddleWindow
{
    /// <summary>
    /// Interaction logic for MiddleView.xaml
    /// </summary>
    public partial class MiddleView : UserControl
    {
        public MiddleView()
        {
            InitializeComponent();
        }

        private void OnMaterialChoseClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MiddleViewModel middleViewModel)
            {
                if (middleViewModel.SelectedMaterial == null)
                    MessageBox.Show("Odaberi materijal", "Poruka", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (middleViewModel.Material != null && middleViewModel.Material.MaterialID == middleViewModel.SelectedMaterial.MaterialID)
                    MessageBox.Show("Odabran je isti materijal", "Poruka", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    middleViewModel.ChoseMaterialCommand.Execute(null);
                    MessageBox.Show($"Izabran je materijal: {middleViewModel.SelectedMaterial}", "Poruka", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void OnNextClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MiddleViewModel middleViewModel)
            {
                if (middleViewModel.Material == null)
                    MessageBox.Show("Najpre odaberi materijal", "Poruka", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    middleViewModel.NextCommand.Execute(null);
            }
        }
    }
}