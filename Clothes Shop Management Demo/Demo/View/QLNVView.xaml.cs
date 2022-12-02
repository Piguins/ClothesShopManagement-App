using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo.View
{
    /// <summary>
    /// Interaction logic for QLNVView.xaml
    /// </summary>
    public partial class QLNVView : Page
    {
        public static Frame MainFrame { get; set; }
        public QLNVView()
        {
            InitializeComponent();
        }

        private void cbxChon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
