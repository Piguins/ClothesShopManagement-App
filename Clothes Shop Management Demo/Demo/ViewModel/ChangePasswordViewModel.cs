using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        public ICommand CancelCM { get; set; }
        public ChangePasswordViewModel()
        {
          
        }
    }
}
