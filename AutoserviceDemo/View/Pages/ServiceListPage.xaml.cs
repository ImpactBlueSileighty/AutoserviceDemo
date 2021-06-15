using AutoserviceDemo.ViewModel;
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

namespace AutoserviceDemo.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        ServiceListViewModel VM;
        public ServiceListPage()
        {
            VM = new ServiceListViewModel();
            DataContext = VM;
            InitializeComponent();
        }

        private void OpenWindow(bool NewService)
        {
            this.Opacity = 0.4;
            if (NewService)
            {

            }
            else
            {
                
            }
            this.Opacity = 1;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e) => VM.Delete();
        
    }
}
