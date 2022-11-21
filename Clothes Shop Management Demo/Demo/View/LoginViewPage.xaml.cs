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
    /// Interaction logic for LoginViewPage.xaml
    /// </summary>
    public partial class LoginViewPage : Page
    {
        public LoginViewPage()
        {
            InitializeComponent();
        }

        private void OpenSignUp(object sender, RoutedEventArgs e)
        {
            SignUpView signUpView = new SignUpView();
            signUpView.Show();
        }

        private void OpenMainView(object sender, RoutedEventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
        }
    }
}
