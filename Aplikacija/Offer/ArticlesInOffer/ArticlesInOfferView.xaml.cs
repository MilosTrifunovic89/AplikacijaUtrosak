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

namespace Aplikacija.Offer.ArticlesInOffer
{
    /// <summary>
    /// Interaction logic for ArticlesInOfferView.xaml
    /// </summary>
    public partial class ArticlesInOfferView : UserControl
    {
        public ArticlesInOfferView()
        {
            InitializeComponent();
        }

        private void OnFocus_Event(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).SelectAll();
            else if (sender is PasswordBox)
                (sender as PasswordBox).SelectAll();
        }
    }
}
