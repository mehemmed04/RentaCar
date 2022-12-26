using RentaCar.Domain.Commands;
using RentaCar.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentaCar.Domain.ViewModels
{
    public class UserAutherizationViewModel:BaseViewModel
    {
        private UserAutherizationWindow _userWindow;
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public RelayCommand LoginCommand { get; set; }
        public UserAutherizationViewModel(UserAutherizationWindow userWindow)
        {
            _userWindow = userWindow;
            LoginCommand = new RelayCommand((o) =>
            {
                var user = App.DB.UserRepository.GetAll().FirstOrDefault(x => x.Username == username);
                if (user == null) MessageBox.Show("User not found");
                else
                {
                    if (user.Passsword == Password)
                    {
                        UserViewModel uvm = new UserViewModel(user.Id);
                        UserView uv = new UserView();
                        uv.DataContext = uvm;
                        uv.Show();
                        _userWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
            });
        }
    }
}
