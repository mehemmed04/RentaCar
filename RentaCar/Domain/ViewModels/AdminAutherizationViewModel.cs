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
    public class AdminAutherizationViewModel:BaseViewModel
    {
        private AdminAutherizationWindow _adminWindow;
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
        public AdminAutherizationViewModel(AdminAutherizationWindow adminWindow)
        {
            _adminWindow = adminWindow;
            LoginCommand = new RelayCommand((o) =>
            {
                var admin = App.DB.AdminRepository.GetAll().FirstOrDefault(x => x.Username == username );
                if (admin == null) MessageBox.Show("Admin not found");
                else
                {
                    if (admin.Passsword == Password)
                    {
                        AdminViewModel avm = new AdminViewModel();
                        AdminView av = new AdminView();
                        av.DataContext = avm;
                        av.Show();
                        _adminWindow.Close();
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
