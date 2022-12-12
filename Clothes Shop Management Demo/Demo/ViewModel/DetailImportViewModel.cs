using Demo.Model;
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModel
{
    class DetailImportViewModel
    {
        public ICommand Loadwd { get; set; }
        public ICommand Back { get; set; }
        public ICommand Delete { get; set; }
        public DetailImportViewModel()
        {
            Back = new RelayCommand<DetailImport>((p) => true, (p) => _Back(p));
            Delete = new RelayCommand<DetailImport>((p) => true, (p) => _Delete(p));
        }
        void _Back(DetailImport p)
        {
            ImportView importView = new ImportView();
            MainViewModel.MainFrame.Content = importView;
        }
        void _Delete(DetailImport parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa phiếu nhập này?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (PHIEUNHAP temp in DataProvider.Ins.DB.PHIEUNHAPs)
                {
                    if (temp.MAPN == int.Parse(parameter.MaPN.Text))
                    {
                        foreach (CTPN temp1 in temp.CTPNs)
                        {
                            foreach (SANPHAM temp2 in DataProvider.Ins.DB.SANPHAMs)
                            {
                                if (temp1.MASP == temp2.MASP)
                                {
                                    if (temp2.SL - temp1.SL < 0)
                                    {
                                        MessageBox.Show("Không thể xóa phiếu nhập vì sản phẩm nhập đã được bán !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return;
                                    }
                                    else
                                        temp2.SL -= temp1.SL;
                                }
                            }
                        }
                        DataProvider.Ins.DB.PHIEUNHAPs.Remove(temp);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                ImportView importView = new ImportView();
                importView.ListViewPN.ItemsSource = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
                MainViewModel.MainFrame.Content = importView;
            }
        }
    }
}
