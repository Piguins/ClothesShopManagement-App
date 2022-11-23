using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Demo.ViewModel
{
    internal class MainViewModel
    {
        public ICommand LogOutCommand { get; set; }

        public MainViewModel()
        {
            LogOutCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) => LogOut(p));
        }
        void LogOut(MainWindow p)
        {
            LoginView login = new LoginView();
            login.Show();
        }
    }
}
