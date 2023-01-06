using RentaCar.Domain.Commands;
using RentaCar.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.ViewModels
{
    public class EmailAuthentificationWiewModel:BaseViewModel
    {
        private EmailAuthentificationWindow _window { get; set; }
        public bool HasAuthentification { get; set; }
        private string code1;

        public string Code1
        {
            get { return code1; }
            set { code1 = value; OnPropertyChanged(); }
        }
        private string code2;

        public string Code2
        {
            get { return code2; }
            set { code2 = value; OnPropertyChanged(); }
        }
        private string code3;

        public string Code3
        {
            get { return code3; }
            set { code3 = value; OnPropertyChanged(); }
        }

        private string code4;

        public string Code4
        {
            get { return code4; }
            set { code4 = value; OnPropertyChanged(); }
        }
        private string code5;

        public string Code5
        {
            get { return code5; }
            set { code5 = value; OnPropertyChanged(); }
        }
        private string incorretCode;

        public string IncorrectCode
        {
            get { return incorretCode; }
            set { incorretCode = value; OnPropertyChanged(); }
        }
        public RelayCommand CheckCommand { get; set; }
        private string _code { get; set; }

        public EmailAuthentificationWiewModel(EmailAuthentificationWindow window, string code)
        {
            _window = window;
            _code = code;
            CheckCommand = new RelayCommand((o) =>
            {
                string newcode = Code1 + Code2 + Code3 + Code4 + Code5;
                HasAuthentification = newcode == _code;
                
                if (HasAuthentification)
                {
                    _window.Close();
                }
                else
                {
                    IncorrectCode = "Incorrect Code";
                }
                Code1 = string.Empty;
                Code2 = string.Empty;
                Code3 = string.Empty;
                Code4 = string.Empty;
                Code5 = string.Empty;
            });
        }

    }
}
