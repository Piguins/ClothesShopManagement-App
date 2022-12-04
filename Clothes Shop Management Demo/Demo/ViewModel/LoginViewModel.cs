using Demo.Model;
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static bool IsLogin { get; set; }
        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public static Frame MainFrame { get; set; }
      
        public Button LoginButton { get; set; }

        public ICommand LoginCM { get; set; }

        public ICommand LoadLoginPageCM { get; set; }

        public ICommand ForgotPassCM { get; set; }

        public ICommand Login { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            Username = "";

            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new LoginViewPage();
            });

            ForgotPassCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ForgetPassView();
            });

            LoginCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Window oldWindow = App.Current.MainWindow;
                MainView mainView = new MainView();
                App.Current.MainWindow = oldWindow;
                oldWindow.Close();
                mainView.Show();

            });

        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public void login(LoginView p)
        {
            try
            {
                if (p == null) return;
                string PassEncode = MD5Hash(Base64Encode(Password));
                var accCount = DataProvider.Ins.DB.NGUOIDUNG.Where(x => x.USERNAME == Username && x.PASS == PassEncode && x.TTND).Count();
                if (accCount > 0)
                {
                    IsLogin = true;
                    Const.TenDangNhap = Username;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Username = "";
                    p.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK);
                }
            }
            catch
            {
                MessageBox.Show("Mất kết nối đến cơ sở dữ liệu!", "Thông báo", MessageBoxButton.OK);
            }
        }
    }

}
