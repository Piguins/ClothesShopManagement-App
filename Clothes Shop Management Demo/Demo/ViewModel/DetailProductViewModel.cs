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
    public class DetailProductViewModel : BaseViewModel
    {
        public ICommand Back { get; set; }
        public ICommand UpdateProduct { get; set; }
        public ICommand GetName { get; set; }
        private string TenSP1;
        public ICommand Loadwd { get; set; }
        public ICommand DeleteProduct { get; set; }
        public DetailProductViewModel()
        {
            GetName = new RelayCommand<DetailsProduct>((p) => true, (p) => _GetName(p));
            Back = new RelayCommand<DetailsProduct>((p) => true, (p) => _Back(p));
            UpdateProduct = new RelayCommand<DetailsProduct>((p) => true, (p) => _UpdateProduct(p));
            Loadwd = new RelayCommand<DetailsProduct>((p) => true, (p) => _Loadwd(p));
            DeleteProduct = new RelayCommand<DetailsProduct>((p) => true, (p) => _DeleteProduct(p));
        }
        void _Loadwd(DetailsProduct parmater)
        {
            if (Const.Admin)
            {
                parmater.TenSP.IsEnabled = true;
                parmater.Mota.IsEnabled = true;
                parmater.btncapnhat.Visibility = Visibility.Visible;
                parmater.btnxoa.Visibility = Visibility.Visible;
            }
            else
            {
                parmater.TenSP.IsEnabled = false;
                parmater.Mota.IsEnabled = false;
                parmater.Mota.Height = 200;
            }
        }
        void _Back(DetailsProduct p)
        {
            ProductViewPage productViewPage = new ProductViewPage();
            MainViewModel.MainFrame.Content = productViewPage;
        }
        void _DeleteProduct(DetailsProduct parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa sản phẩm ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (SANPHAM a in DataProvider.Ins.DB.SANPHAMs.Where(pa => (pa.TENSP == TenSP1 && pa.SL >= 0)))
                {
                    a.SL = -1;
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa sản phẩm thành công !", "THÔNG BÁO");
                ProductViewPage productView = new ProductViewPage();
                productView.ListViewProduct.ItemsSource = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL > 0));
                MainViewModel.MainFrame.Content = productView;
            }
        }
        void _GetName(DetailsProduct p)
        {
            TenSP1 = p.TenSP.Text;
        }
        void _UpdateProduct(DetailsProduct p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn cập nhật sản phẩm ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenSP.Text) || string.IsNullOrEmpty(p.Mota.Text) || string.IsNullOrEmpty(p.Mota.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                else
                {
                    foreach (SANPHAM a in DataProvider.Ins.DB.SANPHAMs.Where(pa => (pa.TENSP == TenSP1 && pa.SL >= 0)))
                    {
                        a.TENSP = p.TenSP.Text;
                        a.MOTA = p.Mota.Text;
                        a.MOTA = p.Mota.Text;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật sản phẩm thành công !", "THÔNG BÁO");
                    ProductViewPage productView = new ProductViewPage();
                    productView.ListViewProduct.ItemsSource = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs);
                    MainViewModel.MainFrame.Content = productView;
                }
            }
        }
    }
}
