using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo.View
{
    /// <summary>
    /// Interaction logic for NotiCustomer.xaml
    /// </summary>
    public partial class NotiCustomer : Page
    {
        public NotiCustomer()
        {
            InitializeComponent();
        }

        List<string> _lstFilePath;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select attached files";
            file.Multiselect = true;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == true)
            {
                _lstFilePath = new List<string>();
                foreach (var item in file.FileNames)
                {
                    _lstFilePath.Add(item);
                    if(!File.Exists(item))
                    {
                        MessageBox.Show("File does not exist", "Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }    
                }    
            }
        }
    }
}
