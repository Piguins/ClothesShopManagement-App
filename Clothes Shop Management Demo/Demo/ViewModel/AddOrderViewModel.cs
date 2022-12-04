using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class HienThi
    {
        public string MaSp { get; set; }
        public string TenSP { get; set; }
        public int SL { get; set; }
        public int Dongia { get; set; }
        public int Tong { get; set; }
        public string Size { get; set; }
        public HienThi(string MaSp = "", string TenSP = "", string Size = "", int SL = 0, int Dongia = 0, int Tong = 0)
        {
            this.MaSp = MaSp;
            this.TenSP = TenSP;
            this.SL = SL;
            this.Tong = Tong;
            this.Size = Size;
            this.Dongia = Dongia;
        }
    }
    public class AddOrderViewModel : BaseViewModel
    {

    }
}
