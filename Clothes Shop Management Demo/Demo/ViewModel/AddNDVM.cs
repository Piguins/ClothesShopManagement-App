using Demo.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Demo.ViewModel
{
    internal class AddNDVM : BaseViewModel
    {
        private string _linkaddimage;
        public string linkaddimage { get => _linkaddimage; set { _linkaddimage = value; OnPropertyChanged(); } }
        public ICommand AddNDCommand { get; set; }
        public ICommand AddImage { get; set; }
        public ICommand CancelCM { get; set; }
        public static Frame MainFrame { get; set; }
        public AddNDVM()
        {
            CancelCM = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                MainViewModel.MainFrame.Content = new QLNVView();
            });
            //linkaddimage = Const._localLink + "/Resource/Image/addava.png";
            //AddImage = new RelayCommand<ImageBrush>((p) => true, (p) => _AddImage(p));
        }
        /*void _AddImage(ImageBrush img)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";

            if (open.ShowDialog() == true)
            {
                if (open.FileName != "")
                    linkaddimage = open.FileName;
            };
            Uri fileUri = new Uri(linkaddimage);
            img.ImageSource = new BitmapImage(fileUri);
        }*/ //Cái này là để thêm hình & lưu vào database
            //nhưng mà mình chưa implement Model nên t (Minh)
            //sẽ code tạm là show hình trên cái khung hình đại diện trong cái phần AddNDView.xaml.c
    }
}
