using Demo.Model;
using Demo.View;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class HienThi
    {
        public string MaSp { get; set; }
        public string TenSP { get; set; }
        public int SL { get; set; }
        public int Dongia { get; set; }
        public int Tong { get; set; }
        public string Size { get; set; }
        public HienThi(string MaSp = "", string TenSP = "", string Size = "", int SL = 0, int Dongia = 0, int Tong = 0)
        {
            this.MaSp = MaSp;
            this.TenSP = TenSP;
            this.SL = SL;
            this.Tong = Tong;
            this.Size = Size;
            this.Dongia = Dongia;
        }
    }
    public class AddOrderViewModel : BaseViewModel
    {
       
        public ICommand Loadwd { get; set; }
        public ICommand Choose { get; set; }
        private List<KHACHHANG> _LKH;
        public List<KHACHHANG> LKH { get => _LKH; set { _LKH = value; OnPropertyChanged(); } }
        private List<SANPHAM> _LSP;
        public List<SANPHAM> LSP { get => _LSP; set { _LSP = value; OnPropertyChanged(); } }
        private ObservableCollection<HienThi> _LHT;
        public ObservableCollection<HienThi> LHT { get => _LHT; set { _LHT = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _LSPSelected;
        public ObservableCollection<string> LDG { get; set; }
        public ObservableCollection<SANPHAM> LSPSelected { get => _LSPSelected; set { _LSPSelected = value; OnPropertyChanged(); } }
        private ObservableCollection<CTHD> _LCTHD;
        public ObservableCollection<CTHD> LCTHD { get => _LCTHD; set { _LCTHD = value; OnPropertyChanged(); } }
        public int km { get; set; }
        public ICommand AddSP { get; set; }
        public ICommand DeleteSP { get; set; }
        public ICommand PrintSP { get; set; }
        public ICommand SaveHD { get; set; }
        public ICommand chooseKH { get; set; }
        public int tongtien { get; set; }
        public int tienkm { get; set; }
        public AddOrderViewModel()
        {
            tongtien = 0;
            tienkm = 0;
            LSPSelected = new ObservableCollection<SANPHAM>();
            LDG = new ObservableCollection<string>() { "1", "2", "3", "4", "5" };
            LHT = new ObservableCollection<HienThi>();
            LCTHD = new ObservableCollection<CTHD>();
            Loadwd = new RelayCommand<AddOrderView>((p) => true, (p) => _Loadwd(p));
            Choose = new RelayCommand<AddOrderView>((p) => true, (p) => _Choose(p));
            chooseKH = new RelayCommand<AddOrderView>((p) => true, (p) => _chooseKH(p));
            AddSP = new RelayCommand<AddOrderView>((p) => true, (p) => _AddSP(p));
            DeleteSP = new RelayCommand<AddOrderView>((p) => true, (p) => _DeleteSP(p));
            //PrintSP = new RelayCommand<AddOrderView>((p) => true, (p) => print(p));
            SaveHD = new RelayCommand<AddOrderView>((p) => true, (p) => _SaveHD(p));
        }
      
        void _Loadwd(AddOrderView paramater)
        {
            LKH = DataProvider.Ins.DB.KHACHHANGs.ToList();
            LSP = DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0).ToList();
            paramater.KH.ItemsSource = LKH;
            paramater.SP.ItemsSource = LSP;
            paramater.MaND.Text = Const.ND.MAND;
            paramater.TenND.Text = Const.ND.TENND;
            paramater.Ngay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
            paramater.TT1.Text = String.Format("{0:0,0}", tongtien) + " VND";
            paramater.GG.Text = "- " + String.Format("{0:0,0}", tienkm) + " VND";
            km = 0;
            paramater.khuyenmai.Text = km.ToString() + "%";
        }
        void _chooseKH(AddOrderView parameter)
        {
            KHACHHANG temp = (KHACHHANG)parameter.KH.SelectedItem;
            if (temp != null)
            {
                int doanhso = 0;
                foreach (HOADON a in DataProvider.Ins.DB.HOADONs)
                {
                    if (a.MAKH == temp.MAKH)
                        doanhso += a.TRIGIA;
                }
                km = 0;
                if (doanhso > 2000000 && doanhso <= 5000000)
                    km = 2;
                else if (doanhso > 5000000 && doanhso <= 10000000)
                    km = 5;
                else if (doanhso > 10000000)
                    km = 10;
                parameter.khuyenmai.Text = km.ToString() + "%";
            }
            else
            {
                km = 0;
                parameter.khuyenmai.Text = "0%";
            }
        }
        void _Choose(AddOrderView paramater)
        {
            if (paramater.SP.SelectedItem != null)
            {
                SANPHAM temp = (SANPHAM)paramater.SP.SelectedItem;
                paramater.DG.Text = String.Format("{0:0,0}", temp.GIA) + " VND"; ;
            }
            else
            {
                paramater.DG.Text = "";
            }
        }
        void _AddSP(AddOrderView paramater)
        {
            if (paramater.SP.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm để thêm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (paramater.SoHD.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số hóa đơn !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (paramater.SL.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số lượng sản phẩm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int so = int.Parse(paramater.SL.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (int.Parse(paramater.SL.Text) < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (paramater.KH.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn khách hàng !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SANPHAM a = (SANPHAM)paramater.SP.SelectedItem;
            if (a.SL >= int.Parse(paramater.SL.Text))
            {
                foreach (HienThi temp in LHT)
                {
                    if (temp.MaSp == a.MASP)
                    {
                        temp.SL += int.Parse(paramater.SL.Text);
                        temp.Tong = temp.SL * a.GIA;
                        foreach (CTHD temp1 in LCTHD)
                        {
                            if (temp1.MASP == a.MASP)
                            {
                                temp1.SL += int.Parse(paramater.SL.Text); ;
                            }
                        }
                        tongtien += int.Parse(paramater.SL.Text) * a.GIA * (100 - km) / 100;
                        tienkm += int.Parse(paramater.SL.Text) * a.GIA * km / 100;
                        paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                        paramater.TT1.Text = String.Format("{0:0,0}", tongtien) + " VND";
                        paramater.GG.Text = "- " + String.Format("{0:0,0}", tienkm) + " VND";
                        paramater.ListViewSP.ItemsSource = LHT;
                        paramater.ListViewSP.Items.Refresh();
                        paramater.SP.SelectedItem = null;
                        paramater.SL.Text = "";
                        return;
                    }
                }
                HienThi b = new HienThi(a.MASP, a.TENSP, a.SIZE, int.Parse(paramater.SL.Text), a.GIA, int.Parse(paramater.SL.Text) * a.GIA);
                CTHD cthd = new CTHD()
                {
                    MASP = a.MASP,
                    SL = int.Parse(paramater.SL.Text),
                    SANPHAM = a,
                    SOHD = int.Parse(paramater.SoHD.Text),
                };
                tongtien += int.Parse(paramater.SL.Text) * a.GIA * (100 - km) / 100;
                tienkm += int.Parse(paramater.SL.Text) * a.GIA * km / 100;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                paramater.TT1.Text = String.Format("{0:0,0}", tongtien) + " VND";
                paramater.GG.Text = "- " + String.Format("{0:0,0}", tienkm) + " VND";
                LCTHD.Add(cthd);
                LHT.Add(b);
                paramater.ListViewSP.ItemsSource = LHT;
                paramater.ListViewSP.Items.Refresh();
                paramater.SP.SelectedItem = null;
                paramater.SL.Text = "";
            }
            else
                System.Windows.MessageBox.Show("Sản phẩm tồn kho không đủ cung cấp !", "THÔNG BÁO");
        }
        void _DeleteSP(AddOrderView paramater)
        {
            if (paramater.ListViewSP.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm để xóa !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sản phẩm.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                HienThi a = (HienThi)paramater.ListViewSP.SelectedItem;
                tongtien -= a.Tong * (100 - km) / 100;
                tienkm -= a.Tong * km / 100;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                paramater.TT1.Text = String.Format("{0:0,0}", tongtien) + " VND";
                paramater.GG.Text = "- " + String.Format("{0:0,0}", tienkm) + " VND";
                LHT.Remove(a);
                foreach (CTHD b in LCTHD)
                {
                    if (b.MASP == a.MaSp && b.SL == a.SL)
                    {
                        LCTHD.Remove(b);
                        break;
                    }
                }
                paramater.SP.ItemsSource = LSP;
                paramater.SP.Items.Refresh();
                paramater.ListViewSP.Items.Refresh();
            }
            else
                return;
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
        void _SaveHD(AddOrderView paramater)
        {
            DataProvider.Ins.DB.SaveChangesAsync();
            if (paramater.KH.SelectedItem == null || paramater.ListViewSP.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Thông tin hóa đơn chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn thanh toán ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                KHACHHANG a = (KHACHHANG)paramater.KH.SelectedItem;
                int tonggia = 0;
                foreach (HienThi b in LHT)
                {
                    tonggia += b.Tong;
                }
                double tien = (double)(1 - (double)km / 100) * tonggia;
                HOADON temp = new HOADON()
                {
                    SOHD = int.Parse(paramater.SoHD.Text),
                    MAKH = a.MAKH,
                    MAND = Const.ND.MAND,
                    NGHD = DateTime.Now,
                    CTHDs = new ObservableCollection<CTHD>(LCTHD),
                    TRIGIA = (int)tien,
                    KHACHHANG = a,
                    NGUOIDUNG = Const.ND,
                    KHUYENMAI = km
                };
                foreach (CTHD s in LCTHD)
                {
                    foreach (SANPHAM x in DataProvider.Ins.DB.SANPHAMs)
                    {
                        if (x.MASP == s.SANPHAM.MASP)
                        {
                            x.SL -= s.SL;
                        }
                    }
                }
                DataProvider.Ins.DB.HOADONs.Add(temp);
                DataProvider.Ins.DB.SaveChanges();
                //MessageBoxResult d = System.Windows.MessageBox.Show("  Bạn có muốn in hóa đơn ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                //if (d == MessageBoxResult.Yes)
                //{
                //    print(paramater);
                //}
                tongtien = 0;
                km = 0;
                tienkm = 0;
                LSPSelected.Clear();
                paramater.KH.SelectedItem = null;
                LHT.Clear();
                LCTHD.Clear();
                paramater.ListViewSP.ItemsSource = LHT;
                paramater.TT.Text = tongtien.ToString();
                paramater.GG.Text = "- " + tienkm.ToString();
                paramater.TT1.Text = tongtien.ToString();
                paramater.SoHD.Text = rdma().ToString();
                MessageBox.Show("Thanh toán hóa đơn thành công !", "THÔNG BÁO");
                OrderView orderView = new OrderView();
                orderView.ListViewHD.ItemsSource = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
                MainViewModel.MainFrame.Content = orderView;
            }
            else
                return;
        }
     
    }
}
