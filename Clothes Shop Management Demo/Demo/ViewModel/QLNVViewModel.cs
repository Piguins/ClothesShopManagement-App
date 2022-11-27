using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demo.ViewModel
{
    internal class QLNVViewModel
    {
        public ICommand AddNVPage { get; set; }
        public static Frame MainFrame { get; set; }
        public QLNVViewModel()
        {
            AddNVPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new QLNVView();
            });

        }
    }
}
