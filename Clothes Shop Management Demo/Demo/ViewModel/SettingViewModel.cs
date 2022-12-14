using Demo.View;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace Demo.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _DoB;
        public string DoB { get => _DoB; set { _DoB = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _Mail;
        public string Mail { get => _Mail; set { _Mail = value; OnPropertyChanged(); } }
        private int _GioiTinh;
        public int GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private string _TenTK;
        public string TenTK { get => _TenTK; set { _TenTK = value; OnPropertyChanged(); } }
        private NGUOIDUNG _User;
        public NGUOIDUNG User { get => _User; set { _User = value; OnPropertyChanged(); } }
        public ICommand Loadwd { get; set; }
        public ICommand UpdateInfo { get; set; }
        public ICommand AddImage { get; set; }
        public ICommand ChangePass { get; set; }
        public SettingViewModel()
        {
            Loadwd = new RelayCommand<SettingView>((p) => true, (p) => _Loadwd(p));
            AddImage = new RelayCommand<ImageBrush>((p) => true, (p) => _AddImage(p));
            UpdateInfo = new RelayCommand<SettingView>((p) => true, (p) => _UdpateInfo(p));
            ChangePass = new RelayCommand<SettingView>((p) => true, (p) => _ChangePass());
        }
        void _ChangePass()
        {
            ChangePassword change = new ChangePassword();
            MainViewModel.MainFrame.Content = change;
        }
        void _AddImage(ImageBrush p)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                Ava = open.FileName;
            }
            p.ImageSource = new BitmapImage(new Uri(Ava));
        }
        void _Loadwd(SettingView p)
        {
            if (LoginViewModel.IsLogin)
            {
                string a = Const.TenDangNhap;
                User = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.USERNAME == a).FirstOrDefault();
                Ava = User.AVA;
                Name = User.TENND;
                DoB = User.NGSINH.ToString();
                DiaChi = User.DIACHI;
                GioiTinh = (User.GIOITINH == "Nam") ? 0 : 1;
                SDT = User.SDT;
                TenTK = User.USERNAME;
                Mail = User.MAIL;
            }
        }
        void _UdpateInfo(SettingView p)
        {
            foreach (NGUOIDUNG temp2 in DataProvider.Ins.DB.NGUOIDUNGs)
            {
                if (temp2.MAIL == p.Mail.Text && p.Mail.Text != Const.ND.MAIL)
                {
                    MessageBox.Show("Email này đã được sử dụng !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reg = new Regex(match);
            if (!reg.IsMatch(p.Mail.Text))
            {
                MessageBox.Show("Email không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var temp = DataProvider.Ins.DB.NGUOIDUNGs.Where(pa => pa.USERNAME == TenTK).FirstOrDefault();
            temp.TENND = p.NameBox.Text;
            temp.SDT = p.SDTBox.Text;
            temp.DIACHI = p.AddressBox.Text;
            temp.GIOITINH = p.GTBox.Text;
            temp.NGSINH = (DateTime)p.DateBox.SelectedDate;
            temp.MAIL = p.Mail.Text;
            string rd = StringGenerator();
            if (User.AVA != Ava)
                temp.AVA = "/Resource/Ava/" + rd + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString();
            DataProvider.Ins.DB.SaveChanges();
            try
            {
                if (User.AVA != Ava)
                    File.Copy(Ava, Const._localLink + @"Resource/Ava/" + rd + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString(), true);
            }
            catch { }
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
        }
        static string StringGenerator()
        {
            Random rd = new Random();
            int length = rd.Next(5, 20);
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
