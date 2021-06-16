using AutoserviceDemo.Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static AutoserviceDemo.Model.EF.AppData;

namespace AutoserviceDemo.ViewModel
{
    class ServiceListViewModel : INotifyPropertyChanged
    {
        public List<Service> Services { get; set; }
        public Service SelectedService { get; set; }

        public List<string> Discounts { get; set; }
        private string _selectedDiscount;
        public string SelectedDiscount 
        { get => _selectedDiscount;
            set
            {
                _selectedDiscount = value;
                Filter();
            } 
        }

        private string _inputTitle;
        public string InputTitle
        {
            get => _inputTitle;
            set
            {
                _inputTitle = value;
                Filter();
            }
        }

        public List<string> ItemsOnPage { get; set; }
        private string _selectedItem;
        public string SelectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Filter();
            }
        }

        //от 0 до 5%, от 5% до 15%, от 15% до 30%, от 30% до 70%, от 70% до 100%
        public ServiceListViewModel()
        {
            string[] discounts = { "от 0 до 5%", "от 5% до 15%", "от 15% до 30%", "от 30% до 70%", "от 70% до 100%" };
            Discounts = new List<string>();
            Discounts.Add("Все");
            Discounts.AddRange(discounts);
            SelectedDiscount = Discounts[0];


            string[] items = { "15", "30", "50" };
            ItemsOnPage = new List<string>();
            ItemsOnPage.Add("Все");
            ItemsOnPage.AddRange(items);
            SelectedItem = ItemsOnPage[0];


            Filter();
        }

        public void Filter()
        {
            Services = context.Service.ToList();

            if (SelectedDiscount == "от 0 до 5%")
                Services = context.Service.Where(e => (e.Discount * 100) >= 0 && (e.Discount * 100) < 5).ToList();

            if (SelectedDiscount == "от 5% до 15%")
                Services = context.Service.Where(e => (e.Discount * 100) >= 5 && (e.Discount * 100) < 15).ToList();

            if (SelectedDiscount == "от 15% до 30%")
                Services = context.Service.Where(e => (e.Discount * 100) >= 15 && (e.Discount * 100) < 30).ToList();

            if (SelectedDiscount == "от 30% до 70%")
                Services = context.Service.Where(e => (e.Discount * 100) >= 30 && (e.Discount * 100) < 70).ToList();

            if (SelectedDiscount == "от 70% до 100%")
                Services = context.Service.Where(e => (e.Discount * 100) >= 70 && (e.Discount * 100) < 100).ToList();

            if (!String.IsNullOrWhiteSpace(InputTitle))
                Services = context.Service.Where(e => e.Title.Contains(InputTitle)).ToList();
            
            

            if (SelectedItem == "15")
                Services = context.Service.OrderBy(e => e.ID).Take(15).ToList();

            if (SelectedItem == "30")
                Services = context.Service.OrderBy(e => e.ID).Take(30).ToList();

            if (SelectedItem == "50")
                Services = context.Service.OrderBy(e => e.ID).Take(50).ToList();

            OnPropertyChanged(nameof(Services));
        }

        public void Delete()
        {
            var result = MessageBox.Show("Вы действительно хотите удалить эту услугу?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                context.Service.Remove(SelectedService);
            }
            context.SaveChanges();
            Filter();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
