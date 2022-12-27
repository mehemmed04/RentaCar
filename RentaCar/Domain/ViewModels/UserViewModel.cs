using RentaCar.DataAccess.Entities;
using RentaCar.Domain.Commands;
using RentaCar.Services;
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

        private Car rentedSelectedCar;

        public Car RentedSelectedCar
        {
            get { return rentedSelectedCar; }
            set { rentedSelectedCar = value; OnPropertyChanged(); }
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
        public RelayCommand ReturnSelectedCarCommand { get; set; }
        public UserViewModel(int userId)
        {
            UserId = userId;
            Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
            RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
            RentCommand = new RelayCommand((o) =>
            {
                string carname =  SelectedCar.Vendor + ' '+  SelectedCar.Model;
                SelectedCar.UserId = UserId;
                App.DB.CarRepository.Update(SelectedCar);
                Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
                RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
                MessageBox.Show("Rented");
                string body = $"You rented {carname} succesfully";
                var user = App.DB.UserRepository.Get(UserId);
                EmailService.SendEmail(user.Email,body);

            });
            ReturnSelectedCarCommand = new RelayCommand((o) =>
            {
                string carname = RentedSelectedCar.Vendor + ' ' + RentedSelectedCar.Model;
                RentedSelectedCar.UserId = null;
                App.DB.CarRepository.Update(RentedSelectedCar);
                Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
                RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
                MessageBox.Show("Returned");
                string body = $"You returned {carname} succesfully";
                var user = App.DB.UserRepository.Get(UserId);
                EmailService.SendEmail(user.Email, body);
            });
        }
    }
}
