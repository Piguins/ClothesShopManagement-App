using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Demo.View
{
    /// <summary>
    /// Interaction logic for PrintOrdersView.xaml
    /// </summary>
    public partial class PrintOrdersView : Window
    {
        public PrintOrdersView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(PrintView, "Hóa Đơn");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
            
        }
    }
}
