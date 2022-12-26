using RentaCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class UserViewModel:BaseViewModel
    {
        public int UserId { get; set; }
        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }
        public UserViewModel(int userId)
        {
            Cars = App.DB.CarRepository.GetAll().ToList();
            UserId = userId;
        }
    }
}
