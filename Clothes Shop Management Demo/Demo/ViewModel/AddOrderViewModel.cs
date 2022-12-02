using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    internal class AddOrderViewModel
    {

        private ActionCommand minimizewd;

        public ICommand Minimizewd
        {
            get
            {
                if (minimizewd == null)
                {
                    minimizewd = new ActionCommand(PerformMinimizewd);
                }

                return minimizewd;
            }
        }

        private void PerformMinimizewd()
        {
        }

        private ActionCommand closewd;

        public ICommand Closewd
        {
            get
            {
                if (closewd == null)
                {
                    closewd = new ActionCommand(PerformClosewd);
                }

                return closewd;
            }
        }

        private void PerformClosewd()
        {
        }
    }
}
