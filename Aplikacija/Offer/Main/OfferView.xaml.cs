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

namespace Aplikacija.Offer.Main
{
    /// <summary>
    /// Interaction logic for OfferView.xaml
    /// </summary>
    public partial class OfferView : UserControl
    {
        public OfferView()
        {
            InitializeComponent();
        }

        private void OnInsertCommandClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is OfferViewModel offerViewModel)
            {
                if (offerViewModel.SelectedElement == null)
                {
                    MessageBox.Show("Odaberi element koji ubacujes u ponudu");
                    return;
                }
                else if (offerViewModel.Number < 1)
                {
                    MessageBox.Show("Broj komada ne moze biti manji od 1");
                    return;
                }

                offerViewModel.CreateOfferCommand.Execute(null);

                if (!offerViewModel.ElementsForOffer.Contains(offerViewModel.OfferProduct))
                {
                    offerViewModel.InsertCommand.Execute(null);
                    MessageBox.Show("Element uspesno ubacen u ponudu");
                }
                else
                    MessageBox.Show("Element se vec nalazi u ponudi");
            }
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
            else if (sender is PasswordBox)
                (sender as PasswordBox).SelectAll();
        }

        private void OnCheckOfferClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is OfferViewModel offerViewModel)
            {
                if (offerViewModel.ElementsForOffer == null || offerViewModel.ElementsForOffer.Count == 0)
                {
                    MessageBox.Show("Nema artikala u ponudi!");
                    return;
                }
                else
                    offerViewModel.EndInsertCommand.Execute(null);
            }
        }

        private void OnCreateOfferCommandClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is OfferViewModel offerViewModel)
            {
                if (!offerViewModel.CheckOfferFields)
                {
                    MessageBox.Show("Popuni podatke potrebne za kreiranje ponude");
                    return;
                }
                else
                {
                    offerViewModel.CreateCommand.Execute(null);
                    MessageBox.Show("Ponuda je uspesno kreirana");
                }

            }
        }
    }
}
