using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Demo.ViewModel
{
    internal class DetailOrderViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand DeleteOrder { get; set; }
        public ICommand PrintOrderCM { get; set; }

        public DetailOrderViewModel()
        {
            PrintOrderCM = new RelayCommand<DetailsOrder>((p) => true, (p) => _PrintOrderView(p));
            DeleteOrder = new RelayCommand<DetailsOrder>((p) => true, (p) => _DeleteOrder(p));
        }
        void _PrintOrderView(DetailsOrder paramater)
        {

            KHACHHANG tempKH=new KHACHHANG();
            HOADON tempHD=new HOADON();
            foreach (HOADON temp in DataProvider.Ins.DB.HOADONs)
            {
                if (temp.SOHD == int.Parse(paramater.SoHD.Text))
                {
                    tempHD = temp;
                    foreach (KHACHHANG kh in DataProvider.Ins.DB.KHACHHANGs)
                    {
                        if (temp.MAKH==kh.MAKH)
                        {
                            tempKH = kh;
                            break;
                        }
                    }
                    break;
                }
            }

            PrintOrderView printOrderView = new PrintOrderView();
            printOrderView.TenKH.Text = tempKH.HOTEN;
            printOrderView.sdt.Text = tempKH.SDT;
            printOrderView.dc.Text = tempKH.DCHI;
            printOrderView.ngay.Text = tempHD.NGHD.ToShortDateString();
            printOrderView.sohd.Text = paramater.SoHD.Text;
            printOrderView.GG.Text = "- " + String.Format("{0:0,0}", (tempHD.TRIGIA * 100 / (100 - tempHD.KHUYENMAI)) * tempHD.KHUYENMAI / 100) + " VND";
            printOrderView.TT1.Text = String.Format("{0:0,0}", tempHD.TRIGIA) + " VND";
            printOrderView.TT.Text = String.Format("{0:0,0}", tempHD.TRIGIA) + " VND";
            List<HienThi> list = new List<HienThi>();
            foreach (CTHD a in tempHD.CTHDs)
            {
                list.Add(new HienThi(a.MASP, a.SANPHAM.TENSP, a.SANPHAM.SIZE, a.SL, a.SANPHAM.GIA, a.SL * a.SANPHAM.GIA));
            }
            printOrderView.ListSP.ItemsSource = list;
            MainViewModel.MainFrame.Content = printOrderView;
        }
        void _DeleteOrder(DetailsOrder parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa hóa đơn này?", "THÔNG BÁO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (HOADON temp in DataProvider.Ins.DB.HOADONs)
                {
                    if (temp.SOHD == int.Parse(parameter.SoHD.Text))
                    {
                        foreach (CTHD temp1 in temp.CTHDs)
                        {
                            foreach (SANPHAM temp2 in DataProvider.Ins.DB.SANPHAMs)
                            {
                                if (temp1.MASP == temp2.MASP)
                                {
                                    if (temp2.SL == -1)
                                        temp2.SL += temp1.SL + 1;
                                    else if (temp2.SL >= 0)
                                        temp2.SL += temp1.SL;
                                }
                            }
                        }
                        DataProvider.Ins.DB.HOADONs.Remove(temp);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                OrderView orderView = new OrderView();
                orderView.ListViewHD.ItemsSource = new ObservableCollection<HOADON> (DataProvider.Ins.DB.HOADONs);
                MainViewModel.MainFrame.Content = orderView;                
            }
        }
    }
}