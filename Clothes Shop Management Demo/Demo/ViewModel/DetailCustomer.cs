using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace Demo.ViewModel
{
    public class DetailCustomer:BaseViewModel
    {    
        private string MaKH;
        public ICommand GetMAKH { get; set; }
        public ICommand Update { get; set; }
        public ICommand back { get; set; }
        public DetailCustomer()
        {           
            GetMAKH = new RelayCommand<DetailCustomerView>((p) => true, (p) => _GetMAKH(p));
            Update = new RelayCommand<DetailCustomerView>((p) => true, (p) => _Update(p));
            back = new RelayCommand<DetailCustomerView>((p) => true, p => _back(p));
        }
        void _GetMAKH(DetailCustomerView paramater)
        {
            MaKH = paramater.MaKH.Text;
        }
        void _back(DetailCustomerView p)
        {
            CustomersView customersView = new CustomersView();
            MainViewModel.MainFrame.Content = customersView;
        }
        void _Update(DetailCustomerView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn cập nhật thông tin ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenKH.Text) || string.IsNullOrEmpty(p.SDT.Text) || string.IsNullOrEmpty(p.GT.Text) || string.IsNullOrEmpty(p.DC.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var temp = DataProvider.Ins.DB.KHACHHANGs.Where(pa => pa.MAKH == MaKH);
                    foreach (KHACHHANG a in temp)
                    {
                        a.HOTEN = p.TenKH.Text;
                        a.SDT = p.SDT.Text;
                        a.GIOITINH = p.GT.Text;
                        a.DCHI = p.DC.Text;
                        a.EMAIL = p.eMAIL.Text;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công !", "THÔNG BÁO");
                    CustomersView customersView = new CustomersView();
                    customersView.ListViewKH.ItemsSource = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
                    MainViewModel.MainFrame.Content = customersView;
                }
            }
        }
    }
}
