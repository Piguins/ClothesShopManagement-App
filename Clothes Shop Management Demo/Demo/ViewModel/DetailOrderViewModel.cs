using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Demo.ViewModel
{
    public class DetailOrderViewModel : BaseViewModel
    {
        public ICommand Loadwd { get; set; }
        public ICommand DeleteOrder { get; set; }
        public DetailOrderViewModel()
        {
            DeleteOrder = new RelayCommand<DetailsOrder>((p) => true, (p) => _DeleteOrder(p));
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
                MainViewModel.MainFrame.Content = new OrderView();
            }
        }
    }
}