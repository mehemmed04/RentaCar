using RentaCar.DataAccess.Entities;
using RentaCar.Domain.Commands;
using RentaCar.Domain.Views;
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
                string carname = SelectedCar.Vendor + ' ' + SelectedCar.Model;
                Random r = new Random();
                int c1 = r.Next(10000, 99999);
                string code = c1.ToString();

                var user = App.DB.UserRepository.Get(UserId);
                string body = $"Your code : {code}";
                EmailService.SendEmail(user.Email, body);

                EmailAuthentificationWindow ev = new EmailAuthentificationWindow();
                EmailAuthentificationWiewModel ewm = new EmailAuthentificationWiewModel(ev, code);
                ev.DataContext = ewm;
                ev.ShowDialog();

                if (ewm.HasAuthentification)
                {
                    SelectedCar.UserId = UserId;
                    App.DB.CarRepository.Update(SelectedCar);
                    Cars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == null; }).ToList();
                    RentedCars = App.DB.CarRepository.GetAll().Where((c) => { return c.UserId == UserId; }).ToList();
                    MessageBox.Show("Rented");
                    body = $"You rented {carname} succesfully";
                    EmailService.SendEmail(user.Email, body);
                }
                else
                {
                    MessageBox.Show("You have to authorize your email");
                }

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
