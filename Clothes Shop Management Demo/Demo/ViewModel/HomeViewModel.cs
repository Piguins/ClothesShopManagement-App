using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand opendetail { get; set; }
        public ICommand opendetail1 { get; set; }
        public ICommand opendetail2 { get; set; }
        public ICommand Back { get; set; }

        public HomeViewModel()
        {
            opendetail = new RelayCommand<HomeView>((p) => true, (p) => _opendetail(p));
            opendetail1 = new RelayCommand<HomeView>((p) => true, (p) => _opendetail1(p));
            opendetail2 = new RelayCommand<HomeView>((p) => true, (p) => _opendetail2(p));
            Back = new RelayCommand<HomeView>((p) => true, (p) => _Back(p));
        }
        void _opendetail(HomeView p)
        {
            DetailMoi detailMoi = new DetailMoi();
            MainViewModel.MainFrame.Content = detailMoi;
        }
        void _opendetail1(HomeView p)
        {
            DetailMoi1 detailMoi1 = new DetailMoi1();
            MainViewModel.MainFrame.Content = detailMoi1;
        }
        void _opendetail2(HomeView p)
        {
            DetailMoi2 detailMoi2 = new DetailMoi2();
            MainViewModel.MainFrame.Content = detailMoi2;
        }
        void _Back(HomeView p)
        {
            HomeView a = new HomeView();
            MainViewModel.MainFrame.Content = a;
        }
    }

}
