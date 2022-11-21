using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class ForgetPassViewModel : BaseViewModel
    {
        public ICommand CancelCM { get; set; }

        public ForgetPassViewModel()
        {
            CancelCM = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                LoginViewModel.MainFrame.Content = new LoginViewPage();
            });
        }
    }
}
