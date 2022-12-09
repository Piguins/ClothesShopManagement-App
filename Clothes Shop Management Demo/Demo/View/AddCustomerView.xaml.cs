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
using System.Windows.Shapes;
using Xamarin.Forms.Xaml;

namespace Demo.View
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Page
    {
        public AddCustomerView()
        {
            InitializeComponent();
        }

        public void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void lbl_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.MainFrame.Content = new CustomersView();
        }
    }
}
