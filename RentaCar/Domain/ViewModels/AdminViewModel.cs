using RentaCar.DataAccess.Entities;
using RentaCar.Domain.Commands;
using RentaCar.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class AdminViewModel : BaseViewModel
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


        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand ShowRentsCommand { get; set; }
        public AdminViewModel()
        {
            Cars = App.DB.CarRepository.GetAll().ToList();

            AddCommand = new RelayCommand((o) =>
            {


            });
            UpdateCommand = new RelayCommand((o) =>
            {
                App.DB.CarRepository.Update(SelectedCar);
                Cars = App.DB.CarRepository.GetAll().ToList();

            });
            DeleteCommand = new RelayCommand((o) =>
            {
                App.DB.CarRepository.Delete(SelectedCar.Id);
                Cars = App.DB.CarRepository.GetAll().ToList();
            });
            ShowRentsCommand = new RelayCommand((o) =>
            {
                RentViewModel rvm = new RentViewModel();
                RentWindow rv = new RentWindow();
                rv.DataContext = rvm;
                rv.ShowDialog();

            });

        }
    }
}
