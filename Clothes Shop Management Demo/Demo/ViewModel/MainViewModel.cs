using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Demo.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }
        public ICommand LoadPageCM { get; set; }
        public ICommand SignoutCM { get; set; }
        public ICommand SettingCM { get; set; }
        public ICommand ChangePassCM { get; set; }
        public ICommand ImportCM { get; set; }
        public ICommand QuanLyCM { get; set; }
        public ICommand HomeCM { get; set; }
        public ICommand AddNDCM { get; set; }
        public ICommand SPCM { get; set; }
        public ICommand OrderCM { get; set; }
        public ICommand Quyen_Loaded { get; set; }
        public ICommand CsCM { get; set; }
        public ICommand KHCM { get; set; }
        public ICommand TenDangNhap_Loaded { get; set; }
        public ICommand Loadwd { get; set; }

        //public ICommand AddOrder { get; set; } 
        public ICommand ReportCM { get; set; }
        public ICommand AddCustomer { get; set; }
        public ICommand AddProduct { get; set; }
        public ICommand AddImport { get; set; }
        private NGUOIDUNG _User;
        public NGUOIDUNG User { get => _User; set { _User = value; OnPropertyChanged(); } }
        private Visibility _SetQuanLy;
        public Visibility SetQuanLy { get => _SetQuanLy; set { _SetQuanLy = value; OnPropertyChanged(); } }
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }

        public void LoadTenND(MainView p)
        {
            p.TenDangNhap.Text = string.Join(" ", User.TENND.Split().Reverse().Take(2).Reverse());
        }

        void _Loadwd(MainView p)
        {
            if (LoginViewModel.IsLogin)
            {
                string a = Const.TenDangNhap;
                User = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.USERNAME == a).FirstOrDefault();
                Const.ND = User;
                SetQuanLy = User.QTV ? Visibility.Visible : Visibility.Collapsed;
                Const.Admin = User.QTV;
                Ava = User.AVA;
                LoadTenND(p);
            }
        }
        public void LoadQuyen(MainView p)
        {
            p.Quyen.Text = User.QTV ? "Quản lý" : "Nhân viên";
        }

        public MainViewModel()
        {
            Quyen_Loaded = new RelayCommand<MainView>((p) => true, (p) => LoadQuyen(p));
            Loadwd = new RelayCommand<MainView>((p) => true, (p) => _Loadwd(p));
            TenDangNhap_Loaded = new RelayCommand<MainView>((p) => true, (p) => LoadTenND(p));
            LoadPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new HomeView();
            });
            ReportCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ReportView();
            });
            HomeCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new HomeView();
            });

            QuanLyCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new QLNVView();
            });

            OrderCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new OrderView();
            });
            CsCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new CustomersView();
            });

            KHCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new CustomersView();
            });

            SPCM = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ProductViewPage();
            });

            ImportCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ImportView();
            });

            SettingCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new SettingView();
            });

            ChangePassCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ChangePassword();
            });

            AddCustomer = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new AddCustomerView();
            });

            AddNDCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new AddNDView();
            });

            AddProduct = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new AddProductView();
            });

            AddImport = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new AddImpotView();
            });

            SignoutCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParentWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Hide();
                    LoginView w1 = new LoginView();
                    w1.ShowDialog();
                    w.Close();
                }
            });

            FrameworkElement GetParentWindow(FrameworkElement p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }
                return parent;
            }

        }
    }
}
