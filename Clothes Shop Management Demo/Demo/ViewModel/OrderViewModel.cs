using Demo.Model;
using Demo.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class OrderViewModel : BaseViewModel
    {
            private ObservableCollection<HOADON> _listHD;
            public ObservableCollection<HOADON> listHD { get => _listHD; set { _listHD = value; OnPropertyChanged(); } }
            public ICommand OpenAddOrder { get; set; }
            public ICommand SearchCommand { get; set; }
            public ICommand Detail { get; set; }
            public ICommand LoadCsCommand { get; set; }
            private ObservableCollection<string> _listTK;
            public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
            public OrderViewModel()
            {
                listTK = new ObservableCollection<string>() { "Họ tên", "Số HD", "Ngày" };
                listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADON);
            
                SearchCommand = new RelayCommand<OrderView>((p) => true, (p) => _SearchCommand(p));
            
                LoadCsCommand = new RelayCommand<OrderView>((p) => true, (p) => _LoadCsCommand(p));
            }
            void _LoadCsCommand(OrderView parameter)
            {
                parameter.cbxChon.SelectedIndex = 0;
            }
            bool check(int m)
            {
                foreach (HOADON temp in DataProvider.Ins.DB.HOADON)
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
          
            void _SearchCommand(OrderView paramater)
            {
                ObservableCollection<HOADON> temp = new ObservableCollection<HOADON>();
                if (paramater.txbSearch.Text != "")
                {
                    switch (paramater.cbxChon.SelectedItem.ToString())
                    {
                        case "Số HD":
                            {
                                try
                                {
                                    foreach (HOADON s in listHD)
                                    {
                                        if (s.SOHD == int.Parse(paramater.txbSearch.Text))
                                        {
                                            temp.Add(s);
                                        }
                                    }

                                }
                                catch { }
                                break;
                            }
                        case "Họ tên":
                            {
                                foreach (HOADON s in listHD)
                                {
                                    if (s.KHACHHANG.HOTEN.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                    {
                                        temp.Add(s);
                                    }
                                }
                                break;
                            }
                        case "Ngày":
                            {
                                foreach (HOADON s in listHD)
                                {
                                    if (s.NGHD.ToString("dd/MM/yyyy").Contains(paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                foreach (HOADON s in listHD)
                                {
                                    if (s.KHACHHANG.HOTEN.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                    {
                                        temp.Add(s);
                                    }
                                }
                                break;
                            }
                    }
                    paramater.ListViewHD.ItemsSource = temp;
                }
                else
                    paramater.ListViewHD.ItemsSource = listHD;
            }
        }
    }
