
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }
      

        public Button LoginButton { get; set; }

        public ICommand LoginCM { get; set; }

        public ICommand LoadLoginPageCM { get; set; }
        public LoginViewModel()
        {

            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new LoginViewPage();
            });
        }
    }

}
