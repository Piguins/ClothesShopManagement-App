using Demo.View;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Demo.ViewModel
{
    public class QLNVViewModel : BaseViewModel
    {
        private ObservableCollection<NGUOIDUNG> _listND;
        public ObservableCollection<NGUOIDUNG> listND { get => _listND; set { _listND = value; OnPropertyChanged(); } }
        public ICommand linkaddImage { get; set; }
        public ICommand RemoveImage { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand UpdateNDCommand { get; set; }
        public ICommand DeleteNDCommand { get; set; }
        public ICommand AddNDCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }
    
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public ICommand ResetPass { get; set; }
        public QLNVViewModel()
        {

            listND = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.TTND == true && p.MAND != Const.ND.MAND));
            listTK = new ObservableCollection<string>() { "Họ tên", "Mã NV", "SĐT" };
            SearchCommand = new RelayCommand<QLNVView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<QLNVView>((p) => { return p.ListViewND.SelectedItem == null ? false : true; }, (p) => _DetailND(p));
            AddNDCommand = new RelayCommand<QLNVView>((p) => true, (p) => _AddND(p));
            UpdateNDCommand = new RelayCommand<DetailNVView>((p) => true, (p) => _UpdateNDCommand(p));
            DeleteNDCommand = new RelayCommand<DetailNVView>((p) => true, (p) => _DeleteNDCommand(p));
            LoadCsCommand = new RelayCommand<QLNVView>((p) => true, (p) => _LoadCsCommand(p));
            ResetPass = new RelayCommand<DetailNVView>((p) => true, (p) => _ResetPass(p));
        }
       
        void _LoadCsCommand(QLNVView parameter)
        {
            parameter.cbxChon.SelectedIndex = 0;
            listND = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.TTND == true && p.MAND != Const.ND.MAND));
        }
        void _SearchCommand(QLNVView paramater)
        {
            ObservableCollection<NGUOIDUNG> temp = new ObservableCollection<NGUOIDUNG>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã NV":
                        {
                            foreach (NGUOIDUNG s in listND)
                            {
                                if (s.MAND.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Họ tên":
                        {
                            foreach (NGUOIDUNG s in listND)
                            {
                                if (s.TENND.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "SĐT":
                        {
                            foreach (NGUOIDUNG s in listND)
                            {
                                if (s.SDT.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (NGUOIDUNG s in listND)
                            {
                                if (s.TENND.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewND.ItemsSource = temp;
            }
            else
                paramater.ListViewND.ItemsSource = listND;
        }
        void _DetailND(QLNVView paramater)
        {
            DetailNVView detailNDView = new DetailNVView();
            NGUOIDUNG temp = (NGUOIDUNG)paramater.ListViewND.SelectedItem;
            detailNDView.MaND.Text = temp.MAND;
            detailNDView.TenND.Text = temp.TENND;
            detailNDView.SDT.Text = temp.SDT;
            detailNDView.GT.Text = temp.GIOITINH;
            detailNDView.NS.Text = temp.NGSINH.ToString();
            detailNDView.Mail.Text = temp.MAIL;
            detailNDView.DC.Text = temp.DIACHI;
            detailNDView.QTV.Text = temp.QTV == true ? "Quản lý" : "Nhân viên";
            MainViewModel.MainFrame.Content = detailNDView;
            listND = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.TTND == true && p.MAND != Const.ND.MAND));
            paramater.ListViewND.ItemsSource = listND;
            paramater.ListViewND.SelectedItem = null;
        }
        void _UpdateNDCommand(DetailNVView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn cập nhật thông tin ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (NGUOIDUNG a in DataProvider.Ins.DB.NGUOIDUNGs.Where(pa => pa.TTND == true && pa.MAND != Const.ND.MAND))
                {
                    if (a.MAND == p.MaND.Text)
                    {
                        if (p.QTV.Text == "Quản lý")
                            a.QTV = true;
                        else
                            a.QTV = false;
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật thành công !", "THÔNG BÁO");
            }
        }
        void _ResetPass(DetailNVView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show(" Bạn muốn đặt lại mật khẩu ? \n Mật khẩu sau khi đặt lại sẽ là 123456", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (NGUOIDUNG temp in DataProvider.Ins.DB.NGUOIDUNGs)
                {
                    if (temp.MAND == p.MaND.Text)
                        temp.PASS = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode("123456"));
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Đặt lại mật khẩu thành công !", "THÔNG BÁO");
            }
        }
        void _DeleteNDCommand(DetailNVView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa người dùng này ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (NGUOIDUNG a in DataProvider.Ins.DB.NGUOIDUNGs.Where(pa => pa.TTND == true && pa.MAND != Const.ND.MAND))
                {
                    if (a.MAND == p.MaND.Text)
                    {
                        a.TTND = false;
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa người dùng thành công !", "THÔNG BÁO");
            }
        }
        bool check(string m)
        {
            foreach (NGUOIDUNG temp in DataProvider.Ins.DB.NGUOIDUNGs)
            {
                if (temp.MAND == m)
                    return true;
            }
            return false;
        }
        string rdma()
        {
            string ma;
            do
            {
                Random rand = new Random();
                ma = "NV" + rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddND(QLNVView parameter)
        {
            AddNDView addNDView = new AddNDView();
            addNDView.MaND.Text = rdma();
            MainViewModel.MainFrame.Content = addNDView;
            listND = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.TTND == true && p.MAND != Const.ND.MAND));
            parameter.ListViewND.ItemsSource = listND;
            parameter.ListViewND.Items.Refresh();
        }
    }
}

