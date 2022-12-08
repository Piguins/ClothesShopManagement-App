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
    internal class MainViewModel
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
        public ICommand KHCM { get; set; }
        //public ICommand AddOrder { get; set; } 
        public ICommand ReportCM { get; set; }
        public ICommand AddCustomer { get; set; }
        public ICommand AddProduct { get; set; }

        public MainViewModel()
        {
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

            //AddOrder = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    MainFrame.Content = new AddOrderView();
            //});

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
