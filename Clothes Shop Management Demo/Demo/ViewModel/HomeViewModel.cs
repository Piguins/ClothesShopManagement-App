using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewModel
{
    internal class HomeViewModel : BaseViewModel
    {
        public class CacMoi
        {
            public string Anh { get; set; }
            public string Ten { get; set; }
            public string Sđt { get; set; }
            public string BuonBan { get; set; }
        }

        private ObservableCollection<CacMoi> _ListMoi;
        public ObservableCollection<CacMoi> ListMoi { get => _ListMoi; set => _ListMoi = value; }

        public HomeViewModel()
        {
            ListMoi = new ObservableCollection<CacMoi>();
            ListMoi.Add(new CacMoi { Anh = "/Resource/Ava/Tu.jpg", Ten = "Đào Anh Tú", Sđt = "0941520828", BuonBan = "Quần áo" });
            ListMoi.Add(new CacMoi { Anh = "/Resource/Ava/Tu.jpg", Ten = "Đào Anh Tú", Sđt = "0941520828", BuonBan = "Quần áo" });
            ListMoi.Add(new CacMoi { Anh = "/Resource/Ava/Tu.jpg", Ten = "Đào Anh Tú", Sđt = "0941520828", BuonBan = "Quần áo" });
            ListMoi.Add(new CacMoi { Anh = "/Resource/Ava/Tu.jpg", Ten = "Đào Anh Tú", Sđt = "0941520828", BuonBan = "Quần áo" });

            HomeView homeView = new HomeView();
            homeView.ListViewIP.ItemsSource = ListMoi;
            MainViewModel.MainFrame.Content = homeView;
        }
    }
}
