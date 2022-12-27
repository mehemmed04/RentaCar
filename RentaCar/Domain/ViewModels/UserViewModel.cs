using RentaCar.DataAccess.Entities;
using RentaCar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentaCar.Domain.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }

        public int UserId { get; set; }
        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }
        private List<Car> rentedCars;

        public List<Car> RentedCars
        {
            get { return rentedCars; }
            set { rentedCars = value; OnPropertyChanged(); }
        }
        public RelayCommand RentCommand { get; set; }
        public UserViewModel(int userId)
        {
            UserId = userId;
            Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
            RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
            RentCommand = new RelayCommand((o) =>
            {
                SelectedCar.UserId = UserId;
                App.DB.CarRepository.Update(SelectedCar);
                Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
                RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
                MessageBox.Show("Rented");
                string body = $"You rented {SelectedCar.Vendor} {SelectedCar.Model} succesfully";

            });
        }
    }
}
