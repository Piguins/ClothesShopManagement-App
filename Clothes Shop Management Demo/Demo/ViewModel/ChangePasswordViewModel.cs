using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private string _OldPass;
        public string OldPass { get => _OldPass; set { _OldPass = value; OnPropertyChanged(); } }
        private string _NewPass;
        public string NewPass { get => _NewPass; set { _NewPass = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private NGUOIDUNG _User;
        public NGUOIDUNG User { get => _User; set { _User = value; OnPropertyChanged(); } }
        public ICommand MinimizeWd { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand MoveWd { get; set; }
        public ICommand OldPassChangedCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand NewPassChangedCommand { get; set; }
        public ICommand Save { get; set; }
        public ChangePasswordViewModel()
        {
            Save = new RelayCommand<ChangePassword>((p) => true, (p) => SaveNewPass(p));
            OldPassChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => { OldPass = p.Password; });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => { Password = p.Password; });
            NewPassChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => { NewPass = p.Password; });
        }
        void SaveNewPass(ChangePassword p)
        {
            string a = Const.TenDangNhap;
            User = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.USERNAME == a).FirstOrDefault();
            try
            {
                if (Password == "" || OldPass == "" || NewPass == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (User.PASS != MD5Hash(Base64Encode(OldPass)))
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Password == OldPass)
                {
                    MessageBox.Show("Mật khẩu mới không được giống mật khẩu cũ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Password != NewPass)
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    User.PASS = MD5Hash(Base64Encode(Password));
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
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
        public ICommand CancelCM { get; set; }
    }
}
