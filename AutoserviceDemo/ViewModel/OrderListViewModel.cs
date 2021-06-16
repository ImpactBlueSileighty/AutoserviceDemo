using AutoserviceDemo.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoserviceDemo.Model.EF.AppData;

namespace AutoserviceDemo.ViewModel
{
    class OrderListViewModel
    {
        public List<Service> Services { get; set; }
        public Service SelectedService { get; set; }

        public OrderListViewModel()
        {
            Filter();
        }

        private void Filter()
        {
            Services = context.Service.ToList();
        }
    }
}
