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
            PrintOrderCM = new RelayCommand<PrintOrderView>((p) => true, (p) => _PrintOrderView(p));
            DeleteOrder = new RelayCommand<DetailsOrder>((p) => true, (p) => _DeleteOrder(p));
        }
        void _PrintOrderView(PrintOrderView paramater)
        {
            PrintOrderView printOrdersView = new PrintOrderView();
            MainViewModel.MainFrame.Content = printOrdersView;
        }
        void _DeleteOrder(DetailsOrder parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa hóa đơn này?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
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