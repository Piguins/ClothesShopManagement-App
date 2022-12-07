using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Demo.ViewModel
{
    public class AddProductViewModel:BaseViewModel
    {
        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        public ICommand AddImage { get; set; }
        private string _linkimage;
        public string linkimage { get => _linkimage; set { _linkimage = value; OnPropertyChanged(); } }
        public ICommand AddProduct { get; set; }
        public ICommand Loadwd { get; set; }
        public AddProductViewModel()
        {
            linkimage = "/Resource/Image/add.png";
            AddImage = new RelayCommand<Image>((p) => true, (p) => _AddImage(p));
            AddProduct = new RelayCommand<AddProductView>((p) => true, (p) => _AddProduct(p));
            Loadwd = new RelayCommand<AddProductView>((p) => true, (p) => _Loadwd(p));
        }
        void _Loadwd(AddProductView paramater)
        {
            linkimage = "/Resource/Image/add.png";
        }
        void _AddImage(Image img)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                linkimage = open.FileName;
            };
            if (linkimage == "/Resource/Image/add.png")
            {
                Uri fileUri = new Uri(linkimage, UriKind.Relative);
                img.Source = new BitmapImage(fileUri);
            }
            else
            {
                Uri fileUri = new Uri(linkimage);
                img.Source = new BitmapImage(fileUri);
            }
        }
        bool check(string m)
        {
            foreach (SANPHAM temp in DataProvider.Ins.DB.SANPHAMs)
            {
                if (temp.MASP == m)
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
                ma = "PD" + rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddProduct(AddProductView paramater)
        {
            if (string.IsNullOrEmpty(paramater.MaSp.Text) || string.IsNullOrEmpty(paramater.TenSp.Text) || string.IsNullOrEmpty(paramater.LoaiSp.Text) || string.IsNullOrEmpty(paramater.GiaSp.Text) || string.IsNullOrEmpty(paramater.SizeSp.Text) || string.IsNullOrEmpty(paramater.SlSp.Text) || linkimage == "/Resource/Image/add.png")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm sản phẩm mới ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (h == MessageBoxResult.Yes)
                {
                    if (DataProvider.Ins.DB.SANPHAMs.Where(p => p.MASP == paramater.MaSp.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại.", "Thông Báo");
                    }
                    else
                    {
                        SANPHAM a = new SANPHAM();
                        a.MASP = paramater.MaSp.Text;
                        a.TENSP = paramater.TenSp.Text;
                        try
                        {
                            a.GIA = int.Parse(paramater.GiaSp.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (int.Parse(paramater.GiaSp.Text) < 0)
                        {
                            MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        a.LOAISP = paramater.LoaiSp.Text;
                        try
                        {
                            a.SL = int.Parse(paramater.SlSp.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (a.SL < 0)
                        {
                            MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        a.SIZE = paramater.SizeSp.Text;
                        a.MOTA = paramater.MotaSp.Text;
                        a.HINHSP = "/Resource/ImgProduct/" + "product_" + paramater.MaSp.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString();
                        DataProvider.Ins.DB.SANPHAMs.Add(a);
                        DataProvider.Ins.DB.SaveChanges();
                        try
                        {
                            File.Copy(linkimage, _localLink + @"Resource\ImgProduct\" + "product_" + paramater.MaSp.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString(), true);
                        }
                        catch { }
                        MessageBox.Show("Thêm sản phẩm mới thành công !", "THÔNG BÁO");
                        paramater.MaSp.Text = rdma();
                        paramater.TenSp.Clear();
                        paramater.LoaiSp.SelectedItem = null;
                        paramater.GiaSp.Clear();
                        paramater.SlSp.Clear();
                        paramater.SizeSp.SelectedItem = null;
                        Uri fileUri = new Uri(Const._localLink + "/Resource/Image/add.png");
                        paramater.HinhAnh.Source = new BitmapImage(fileUri);
                        paramater.MotaSp.Clear();
                    }
                }
            }
        }
    }
}
