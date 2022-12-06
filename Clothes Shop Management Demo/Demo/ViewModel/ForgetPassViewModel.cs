using Demo.Model;
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class ForgetPassViewModel : BaseViewModel
    {
        public ICommand CancelCM { get; set; }
        public ICommand SendPass { get; set; }

        public ForgetPassViewModel()
        {
            CancelCM = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                LoginViewModel.MainFrame.Content = new LoginViewPage();
            });
            SendPass = new RelayCommand<ForgetPassView>((p) => true, (p) => _SendPass(p));
        }
        void _SendPass(ForgetPassView parameter)
        {
            int dem = DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.MAIL == parameter.MailAddress.Text).Count();
            if (dem == 0)
            {
                MessageBox.Show("Email này chưa được đăng lý !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rand = new Random();
            string newpass = rand.Next(100000, 999999).ToString();
            foreach (NGUOIDUNG temp in DataProvider.Ins.DB.NGUOIDUNGs)
            {
                if (temp.MAIL == parameter.MailAddress.Text)
                {
                    temp.PASS = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(newpass));
                    break;
                }
            }
            DataProvider.Ins.DB.SaveChanges();
            string nd = "Vui lòng nhập mật khẩu " + newpass + " để đăng nhập. Trân trọng !";
            MailMessage message = new MailMessage("vhnm3004@gmail.com", parameter.MailAddress.Text, "Lấy lại mật khẩu", nd);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("vhnm3004@gmail.com", "snnaarxvfndqhptl");
            smtpClient.Send(message);
            MessageBox.Show("Đã gửi mật khẩu vào Email đăng ký !", "Thông báo");
        }
    }
}
