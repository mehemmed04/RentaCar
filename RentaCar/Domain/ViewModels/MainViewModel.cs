using RentaCar.Domain.Commands;
using RentaCar.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private MainWindow mainWindow;

        public RelayCommand AdminCommand { get; set; }
        public RelayCommand UserCommand { get; set; }
       

        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            AdminCommand = new RelayCommand((o) =>
            {
                AdminAutherizationWindow av = new AdminAutherizationWindow();
                AdminAutherizationViewModel avm = new AdminAutherizationViewModel(av);
                av.DataContext = avm;
                av.Show();
                mainWindow.Close();
            });
            UserCommand = new RelayCommand((o) =>
            {
                UserAutherizationWindow uv = new UserAutherizationWindow();
                UserAutherizationViewModel uvm = new UserAutherizationViewModel(uv);
                uv.DataContext = uvm;
                uv.Show();
                mainWindow.Close();
            });
        }
    }
}
