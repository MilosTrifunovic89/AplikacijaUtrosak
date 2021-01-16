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

namespace Aplikacija.Offer.Customer
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void OnCreateCustomerClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CustomerViewModel customerViewModel)
            {
                if (customerViewModel.VisibilityCivilCustomerCreate)
                {
                    if ((String.IsNullOrWhiteSpace(customerViewModel.FirstName)) ||
                    (String.IsNullOrWhiteSpace(customerViewModel.LastName)) ||
                    (String.IsNullOrWhiteSpace(customerViewModel.Address)) ||
                    (String.IsNullOrWhiteSpace(customerViewModel.IDnumber)))
                    {
                        MessageBox.Show("Unesi potrebne podatke za fizicko lice");
                        return;
                    }
                }

                else if (customerViewModel.VisibilityPublicCustomerCreate)
                {
                    if ((String.IsNullOrWhiteSpace(customerViewModel.CompanyName)) ||
                     (String.IsNullOrWhiteSpace(customerViewModel.CompanyAddress)) ||
                     (String.IsNullOrWhiteSpace(customerViewModel.PIB)) ||
                     (String.IsNullOrWhiteSpace(customerViewModel.CompanyIDnumber)))
                    {
                        MessageBox.Show("Unesi potrebne podatke za kompaniju");
                        return;
                    }
                }

                customerViewModel.CreateCustomerCommand.Execute(null);
            }
        }

        private void OnCreateOfferButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CustomerViewModel customerViewModel)
            {
                if (customerViewModel.SelectedCivilCustomer == null && customerViewModel.SelectedPublicCustomer == null)
                {
                    MessageBox.Show("Odaberi kupca");
                    return;
                }
                else if (customerViewModel.SelectedPublicCustomer != null || customerViewModel.SelectedCivilCustomer != null)
                    customerViewModel.CreateOfferCommand.Execute(null);
            }
        }
    }
}
