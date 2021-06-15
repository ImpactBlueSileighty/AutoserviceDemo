using AutoserviceDemo.View.Pages;
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
using System.Windows.Shapes;


namespace AutoserviceDemo.View
{
    /// <summary>
    /// Логика взаимодействия для ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Window
    {
        public ServiceList()
        {
            InitializeComponent();
        }

        private void ServiceListBtn_Click(object sender, RoutedEventArgs e)
        {
            ServiceListPage serviceListPage = new ServiceListPage();
            NavigationFrame.Navigate(serviceListPage);
        }

        private void OrderListBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderListPage orderListPage = new OrderListPage();
            NavigationFrame.Navigate(orderListPage);
        }
    }
}
