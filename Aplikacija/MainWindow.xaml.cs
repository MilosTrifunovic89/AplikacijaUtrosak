using Aplikacija.Common;
using Aplikacija.Main;
using System.Windows;

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ServiceProvider.Instance.GetService(typeof(IMainViewModel));
        }        
    }
}
