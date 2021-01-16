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

namespace Aplikacija.AllProducts.Table.Main
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
        }

        private void OnButtonClickCreateTable_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                if (tableViewModel.WoodenConstruction && (String.IsNullOrWhiteSpace(tableViewModel.TableName) || tableViewModel.Height == 0 || tableViewModel.Width == 0 || tableViewModel.Depth == 0
                        || tableViewModel.BinderWidth == 0))
                {
                    MessageBox.Show("Unesi dimenzije stola");
                    return;
                }

                else if (tableViewModel.MetalConstruction && (String.IsNullOrWhiteSpace(tableViewModel.TableName) || tableViewModel.Width == 0 || tableViewModel.Depth == 0))
                {
                    MessageBox.Show("Unesi dimenzije stola");
                    return;
                }

                tableViewModel.CreateCommand.Execute(null);

                if (tableViewModel.Table != null)
                    MessageBox.Show($"Kreiran je {tableViewModel.Table.ElementName} dimenzija {tableViewModel.Table.Width}/{tableViewModel.Table.Depth}/" +
                        $"{tableViewModel.Table.Height}h");
            }
        }

        private void OnButtonClickChangeMaterial_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                if (tableViewModel.Table == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    tableViewModel.ChangeMaterialCommand.Execute(null);
            }
        }

        private void OnButtonClickEdgeTape_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                if (tableViewModel.Table == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    tableViewModel.EdgeTapeCommand.Execute(null);
            }
        }

        private void OnButtonClickFittings_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                if (tableViewModel.Table == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    tableViewModel.FittingsCommand.Execute(null);
            }
        }

        private void OnButtonClickGetSpecification_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                if (tableViewModel.Table == null)
                    MessageBox.Show("Najpre kreiraj sto");
                else
                    tableViewModel.GetSpecificationCommand.Execute(null);
            }
        }

        private void OnButtonClickResetCommand_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da resetujete sve podatke?", "RESET", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    tableViewModel.ResetCommand.Execute(null);
            }
        }

        private void OnButtonClickInsertIntoBase_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TableViewModel tableViewModel)
            {
                tableViewModel.InsertIntoBaseCommand.Execute(null);
                MessageBox.Show("Element je uspesno unet u bazu");
            }
        }
    }
}
