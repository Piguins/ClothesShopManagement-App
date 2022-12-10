using Demo.Model;
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class Display
    {
        public string MaSp { get; set; }
        public string TenSP { get; set; }
        public int Dongia { get; set; }
        public int SL { get; set; }
        public string Size { get; set; }
        public int Tiennhap { get; set; }
        public Display(string MaSp = "", string TenSP = "", string Size = "", int Dongia = 0, int SL = 0, int Tiennhap = 0)
        {
            this.MaSp = MaSp;
            this.TenSP = TenSP;
            this.SL = SL;
            this.Dongia = Dongia;
            this.Size = Size;
            this.Tiennhap = Tiennhap;
        }
    }
    class ImportViewModel : BaseViewModel
    {
        private ObservableCollection<PHIEUNHAP> _listPN;
        public ObservableCollection<PHIEUNHAP> listPN { get => _listPN; set { _listPN = value; OnPropertyChanged(); } }
        public ICommand OpenAddImport { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ImportViewModel()
        {
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            SearchCommand = new RelayCommand<ImportView>((p) => true, (p) => _SearchCommand(p));
            OpenAddImport = new RelayCommand<ImportView>((p) => true, (p) => _OpenAdd(p));
            Detail = new RelayCommand<ImportView>((p) => p.ListViewPN.SelectedItem != null ? true : false, (p) => _Detail(p));
        }
        bool check(int m)
        {
            foreach (HOADON temp in DataProvider.Ins.DB.HOADONs)
            {
                if (temp.SOHD == m)
                    return true;
            }
            return false;
        }
        int rdma()
        {
            int ma;
            do
            {
                Random rand = new Random();
                ma = rand.Next(0, 10000);
            } while (check(ma));
            return ma;
        }
        void _OpenAdd(ImportView paramater)
        {
            AddImpotView addOrder = new AddImpotView();
            addOrder.MaPN.Text = rdma().ToString();
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            paramater.ListViewPN.ItemsSource = listPN;
            paramater.ListViewPN.Items.Refresh();
            MainViewModel.MainFrame.Content = addOrder;
        }
        void _Detail(ImportView p)
        {
            DetailImport detailImport = new DetailImport();
            PHIEUNHAP temp = (PHIEUNHAP)p.ListViewPN.SelectedItem;
            detailImport.MaND.Text = temp.NGUOIDUNG.MAND;
            detailImport.TenND.Text = temp.NGUOIDUNG.TENND;
            detailImport.Ngay.Text = temp.NGAYNHAP.ToString("dd/MM/yyyy hh:mm tt");
            detailImport.MaPN.Text = temp.MAPN.ToString();
            List<Display> list = new List<Display>();
            int tong = 0;
            foreach (CTPN a in temp.CTPNs)
            {
                list.Add(new Display(a.MASP, a.SANPHAM.TENSP, a.SANPHAM.SIZE, (int)((float)a.SANPHAM.GIA * 5 / 6), a.SL, (int)((float)(a.SL * a.SANPHAM.GIA) * 5 / 6)));
                tong += (int)((float)(a.SL * a.SANPHAM.GIA) * 5 / 6);
            }
            detailImport.ttn.Text = String.Format("{0:#,###}" + " VND", tong);
            detailImport.ListViewSP.ItemsSource = list;
            p.ListViewPN.SelectedItem = null;
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            p.ListViewPN.ItemsSource = listPN;
            _SearchCommand(p);
            MainViewModel.MainFrame.Content = detailImport;
        }
        void _SearchCommand(ImportView p)
        {
            ObservableCollection<PHIEUNHAP> temp = new ObservableCollection<PHIEUNHAP>();
            if (p.txbSearch.Text != "")
            {
                foreach (PHIEUNHAP s in listPN)
                {
                    if (s.NGUOIDUNG.TENND.ToLower().Contains(p.txbSearch.Text.ToLower()))
                    {
                        temp.Add(s);
                    }
                }
                p.ListViewPN.ItemsSource = temp;
            }
            else
                p.ListViewPN.ItemsSource = listPN;
        }
    }
}
