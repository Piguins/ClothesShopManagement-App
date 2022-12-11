using Demo.View;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Demo.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {

        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        private ObservableCollection<SANPHAM> _listSP;
        public ObservableCollection<SANPHAM> listSP { get => _listSP; set { _listSP = value; /*OnPropertyChanged();*/ } }
        private ObservableCollection<SANPHAM> _listSP1;
        public ObservableCollection<SANPHAM> listSP1 { get => _listSP1; set { _listSP1 = value; /*OnPropertyChanged();*/ } }
        public ICommand SearchCommand { get; set; }
        public ICommand DetailPdCommand { get; set; }
        public ICommand AddPdPdCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public ICommand Filter { get; set; }
        public ProductViewModel()
        {
            listTK = new ObservableCollection<string>() { "Tên SP", "Giá SP" };
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
            AddPdPdCommand = new RelayCommand<ProductViewPage>((p) => { return p == null ? false : true; }, (p) => _AddPdCommand(p));
            SearchCommand = new RelayCommand<ProductViewPage>((p) => { return p == null ? false : true; }, (p) => _SearchCommand(p));
            DetailPdCommand = new RelayCommand<ProductViewPage>((p) => { return p.ListViewProduct.SelectedItem == null ? false : true; }, (p) => _DetailPd(p));
            LoadCsCommand = new RelayCommand<ProductViewPage>((p) => true, (p) => _LoadCsCommand(p));
            Filter = new RelayCommand<ProductViewPage>((p) => true, (p) => _Filter(p));
        }
        void _LoadCsCommand(ProductViewPage parameter)
        {
            listTK = new ObservableCollection<string>() { "Tên SP", "Giá SP" };
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
            parameter.cbxBoLoc.SelectedIndex = 0;
            parameter.cbxTimKiem.SelectedIndex = 0;
            _Filter(parameter);
            _SearchCommand(parameter);
        }
        void _Filter(ProductViewPage parameter)
        {
            switch (parameter.cbxBoLoc.SelectedIndex.ToString())
            {
                case "0":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "1":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Áo sơ mi"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "2":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Áo thun"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "3":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Áo trùm đầu"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "4":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Áo khoác"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "5":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Áo tay dài"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "6":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Quần"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "7":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.LOAISP == "Phụ kiện"));
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
            }

        }
        void _SearchCommand(ProductViewPage paramater)
        {
            ObservableCollection<SANPHAM> temp = new ObservableCollection<SANPHAM>();
            if (paramater.tbxSearch.Text != "")
            {
                switch (paramater.cbxTimKiem.SelectedItem.ToString())
                {
                    case "Tên SP":
                        {
                            foreach (SANPHAM s in listSP)
                            {
                                if (s.TENSP.ToLower().Contains(paramater.tbxSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Giá SP":
                        {
                            try
                            {
                                foreach (SANPHAM s in listSP)
                                {
                                    if (s.GIA <= int.Parse(paramater.tbxSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }
                            }
                            catch { }
                            break;
                        }
                    default:
                        {
                            foreach (SANPHAM s in listSP)
                            {
                                if (s.TENSP.ToLower().Contains(paramater.tbxSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewProduct.ItemsSource = temp;
            }
            else
                paramater.ListViewProduct.ItemsSource = listSP;
        }
        void _DetailPd(ProductViewPage paramater)
        {
            DetailsProduct detailProduct = new DetailsProduct();
            SANPHAM temp = (SANPHAM)paramater.ListViewProduct.SelectedItem;
            detailProduct.TenSP.Text = temp.TENSP;
            detailProduct.GiaSP.Text = string.Format("{0:0,0}", temp.GIA) + " VNĐ";
            detailProduct.LoaiSP.Text = temp.LOAISP;
            string SL = listSP1.Where(p => p.TENSP == temp.TENSP && p.SL >= 0).Select(p => p.SL).Sum().ToString();
            detailProduct.SLSP.Text = "Số lượng: " + SL;
            detailProduct.kichco.ItemsSource = new ObservableCollection<SANPHAM>(listSP1.Where(p => p.TENSP == temp.TENSP && p.SL >= 0));
            detailProduct.Mota.Text = temp.MOTA;
            Uri fileUri = new Uri(temp.HINHSP);
            detailProduct.HinhAnh.Source = new BitmapImage(fileUri);
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            paramater.ListViewProduct.ItemsSource = listSP1;
            paramater.ListViewProduct.SelectedItem = null;
            _Filter(paramater);
            _SearchCommand(paramater);
            MainViewModel.MainFrame.Content = detailProduct;
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
        void _AddPdCommand(ProductViewPage paramater)
        {
            AddProductView addProductView = new AddProductView();
            addProductView.MaSp.Text = rdma();
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            _Filter(paramater);
            _SearchCommand(paramater);
            paramater.ListViewProduct.ItemsSource = listSP1;
            paramater.ListViewProduct.Items.Refresh();
            MainViewModel.MainFrame.Content = addProductView;
        }
    }
}
