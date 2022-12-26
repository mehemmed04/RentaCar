using RentaCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class AdminViewModel:BaseViewModel
    {
        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value;OnPropertyChanged(); }
        }
        public AdminViewModel()
        {
            Cars = App.DB.CarRepository.GetAll().ToList();
        }
    }
}
