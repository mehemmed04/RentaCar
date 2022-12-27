using RentaCar.DataAccess.Entities;
using RentaCar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class RentViewModel:BaseViewModel
    {
        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }
        public RentViewModel()
        {
            Cars = App.DB.CarRepository.GetAll().Where((c) => c.UserId != null).ToList();
        }

    }
}
