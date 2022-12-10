using Demo.Model;
using Demo.View;
using Demo.ViewModel;
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
    class AddImportViewModel : BaseViewModel
    {
        private List<SANPHAM> _LSP;
        public List<SANPHAM> LSP { get => _LSP; set { _LSP = value; OnPropertyChanged(); } }
        private ObservableCollection<Display> _LHT;
        public ObservableCollection<Display> LHT { get => _LHT; set { _LHT = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _LSPSelected;
        public ObservableCollection<SANPHAM> LSPSelected { get => _LSPSelected; set { _LSPSelected = value; OnPropertyChanged(); } }
        private ObservableCollection<CTPN> _LCTPN;
        public ObservableCollection<CTPN> LCTPN { get => _LCTPN; set { _LCTPN = value; OnPropertyChanged(); } }
        public ICommand Loadwd { get; set; }
        public ICommand AddSP { get; set; }
        public ICommand DeleteSP { get; set; }
        public ICommand SavePN { get; set; }
        public ICommand Choose { get; set; }
        public int tongtien { get; set; }
        public AddImportViewModel()
        {
            tongtien = 0;
            LSPSelected = new ObservableCollection<SANPHAM>();
            LHT = new ObservableCollection<Display>();
            LCTPN = new ObservableCollection<CTPN>();
            Choose = new RelayCommand<AddImpotView>((p) => true, (p) => _Choose(p));
            Loadwd = new RelayCommand<AddImpotView>((p) => true, (p) => _Loadwd(p));
            AddSP = new RelayCommand<AddImpotView>((p) => true, (p) => _AddSP(p));
            DeleteSP = new RelayCommand<AddImpotView>((p) => true, (p) => _DeleteSP(p));
            SavePN = new RelayCommand<AddImpotView>((p) => true, (p) => _SavePN(p));
        }
        void _Loadwd(AddImpotView paramater)
        {
            LSP = DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0).ToList();
            paramater.SP.ItemsSource = LSP;
            paramater.MaND.Text = Const.ND.MAND;
            paramater.TenND.Text = Const.ND.TENND;
            paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
            paramater.Ngay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        }
        void _Choose(AddImpotView paramater)
        {
            if (paramater.SP.SelectedItem != null)
            {
                SANPHAM temp = (SANPHAM)paramater.SP.SelectedItem;
                paramater.DG.Text = String.Format("{0:#,###} VNĐ", ((int)(float)temp.GIA * 5 / 6));
            }
            else
            {
                paramater.DG.Text = "";
            }
        }
        void _AddSP(AddImpotView paramater)
        {
            if (paramater.MaPN.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã phiếu nhập!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (PHIEUNHAP s in DataProvider.Ins.DB.PHIEUNHAPs)
            {
                if (int.Parse(paramater.MaPN.Text) == s.MAPN)
                {
                    System.Windows.MessageBox.Show("Mã phiếu nhập đã tồn tại !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                if (int.Parse(paramater.SL.Text) < 10)
                {
                    System.Windows.MessageBox.Show("Số lượng nhập không được nhỏ hơn 10!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Số lượng nhập không hợp lệ!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SANPHAM a = (SANPHAM)paramater.SP.SelectedItem;
            foreach (Display display in paramater.ListViewSP.Items)
            {
                if (display.MaSp == a.MASP)
                {
                    display.SL += int.Parse(paramater.SL.Text);
                    display.Tiennhap = display.SL * (int)(a.GIA * 5 / 6);
                    foreach (CTPN ct in LCTPN)
                    {
                        if (ct.MASP == display.MaSp)
                            ct.SL = display.SL;
                    }
                    goto There;
                }
            }
            Display b = new Display(a.MASP, a.TENSP, a.SIZE, (int)((float)a.GIA * 5 / 6), int.Parse(paramater.SL.Text), (int)((float)(int.Parse(paramater.SL.Text) * a.GIA) * 5 / 6));
            CTPN ctpn = new CTPN()
            {
                MASP = a.MASP,
                SL = int.Parse(paramater.SL.Text),
                SANPHAM = a,
                MAPN = int.Parse(paramater.MaPN.Text),
            };
            LCTPN.Add(ctpn);
            LHT.Add(b);
        There:
            tongtien += int.Parse(paramater.SL.Text) * (int)(a.GIA * 5 / 6);
            paramater.ListViewSP.ItemsSource = LHT;
            paramater.ListViewSP.Items.Refresh();
            paramater.SP.ItemsSource = LSP;
            paramater.SP.Items.Refresh();
            paramater.SP.SelectedItem = null;
            paramater.SL.Text = "";
            paramater.TT.Text = tongtien.ToString("#,### VNĐ");
        }
        void _DeleteSP(AddImpotView paramater)
        {
            if (paramater.ListViewSP.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sản phẩm.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                Display a = (Display)paramater.ListViewSP.SelectedItem;
                tongtien -= a.Tiennhap;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                LHT.Remove(a);
                foreach (SANPHAM b in LSPSelected)
                {
                    if (b.MASP == a.MaSp)
                    {
                        LSPSelected.Remove(b);
                        break;
                    }
                }
                foreach (CTPN b in LCTPN)
                {
                    if (b.MASP == a.MaSp && b.SL == a.SL)
                    {
                        LCTPN.Remove(b);
                        break;
                    }
                }
                paramater.ListViewSP.Items.Refresh();
            }
            else
                return;
        }
        void _SavePN(AddImpotView paramater)
        {
            if (paramater.ListViewSP.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Thông tin phiếu nhập chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("Xác nhận nhập hàng?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                PHIEUNHAP temp = new PHIEUNHAP()
                {
                    MAPN = int.Parse(paramater.MaPN.Text),
                    MAND = Const.ND.MAND,
                    NGAYNHAP = DateTime.Now,
                    CTPNs = new ObservableCollection<CTPN>(LCTPN),
                };
                foreach (CTPN s in LCTPN)
                {
                    foreach (SANPHAM x in DataProvider.Ins.DB.SANPHAMs)
                    {
                        if (x.MASP == s.SANPHAM.MASP)
                        {
                            x.SL += s.SL;
                        }
                    }
                }
                DataProvider.Ins.DB.PHIEUNHAPs.Add(temp);
                DataProvider.Ins.DB.SaveChanges();
                System.Windows.MessageBox.Show("Nhập hàng thành công", "THÔNG BÁO");
                LHT = new ObservableCollection<Display>();
                paramater.MaPN.Clear();
                LCTPN = new ObservableCollection<CTPN>();
                paramater.ListViewSP.ItemsSource = LHT;
                LSP = DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0).ToList();
                paramater.SP.Items.Refresh();
                ImportView importView = new ImportView();
                MainViewModel.MainFrame.Content = importView;
            }
            else
                return;
        }
    }
}
