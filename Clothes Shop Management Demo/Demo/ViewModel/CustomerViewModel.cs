using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Demo.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }
        private ObservableCollection<KHACHHANG> _listKH;
        public ObservableCollection<KHACHHANG> listKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand AddCsCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public CustomerViewModel()
        {
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            listTK = new ObservableCollection<string>() { "Họ tên", "Mã KH", "SĐT" };
            SearchCommand = new RelayCommand<CustomersView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<CustomersView>((p) => { return p.ListViewKH.SelectedItem == null ? false : true; }, (p) => _DetailCs(p));
            AddCsCommand = new RelayCommand<CustomersView>((p) => true, (p) => _AddCs(p));
            LoadCsCommand = new RelayCommand<CustomersView>((p) => true, (p) => _LoadCsCommand(p));
        }
        void _LoadCsCommand(CustomersView parameter)
        {
            parameter.cbxChon.SelectedIndex = 0;
        }
        void _SearchCommand(CustomersView paramater)
        {
            ObservableCollection<KHACHHANG> temp = new ObservableCollection<KHACHHANG>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã KH":
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.MAKH.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Họ tên":
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.HOTEN.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "SĐT":
                        {
                            foreach (KHACHHANG s in listKH)
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
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.HOTEN.ToLower().Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewKH.ItemsSource = temp;
            }
            else
                paramater.ListViewKH.ItemsSource = listKH;
        }
        void _DetailCs(CustomersView paramater)
        {
            DetailCustomerView detailCustomerView = new DetailCustomerView();
            KHACHHANG temp = (KHACHHANG)paramater.ListViewKH.SelectedItem;
            detailCustomerView.MaKH.Text = temp.MAKH;
            detailCustomerView.TenKH.Text = temp.HOTEN;
            detailCustomerView.SDT.Text = temp.SDT;
            detailCustomerView.GT.Text = temp.GIOITINH;
            detailCustomerView.DC.Text = temp.DCHI;
            int doanhso = 0;
            foreach (HOADON a in DataProvider.Ins.DB.HOADONs)
            {
                if (a.MAKH == temp.MAKH)
                    doanhso += a.TRIGIA;
            }
            detailCustomerView.DS.Text = String.Format("{0:0,0}", doanhso) + " VND"; ;
            string hang = "Đồng";
            if (doanhso > 2000000 && doanhso <= 5000000)
                hang = "Bạc";
            else if (doanhso > 5000000 && doanhso <= 10000000)
                hang = "Vàng";
            else if (doanhso > 10000000)
                hang = "Kim cương";
            detailCustomerView.Rank.Text = hang;
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            paramater.ListViewKH.ItemsSource = listKH;
            paramater.ListViewKH.SelectedItem = null;
            MainViewModel.MainFrame.Content = detailCustomerView;
        }
        bool check(string m)
        {
            foreach (KHACHHANG temp in DataProvider.Ins.DB.KHACHHANGs)
            {
                if (temp.MAKH == m)
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
                ma = "KH" + rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddCs(CustomersView paramater)
        {
            AddCustomerView addCustomerView = new AddCustomerView();
            addCustomerView.MaKH.Text = rdma().ToString();
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            paramater.ListViewKH.ItemsSource = listKH;
            paramater.ListViewKH.Items.Refresh();
            MainViewModel.MainFrame.Content = addCustomerView;
        }
    }
}
