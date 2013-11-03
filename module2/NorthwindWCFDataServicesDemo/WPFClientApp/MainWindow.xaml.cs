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
using System.Data.Services.Client;

namespace WPFClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthwindDataServices.northwindEntities _proxy;
        private DataServiceCollection<NorthwindDataServices.Customers> _customers = new DataServiceCollection<NorthwindDataServices.Customers>();
        public MainWindow()
        {
            InitializeComponent();
            _proxy = new NorthwindDataServices.northwindEntities(new Uri("http://localhost:28510/NorthwindDataService.svc"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _customers.Load(_proxy.Customers);
            this.ResultGrid.ItemsSource = _customers;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _proxy.SaveChanges();
        }
    }
}
