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
    /// Interaction logic for DetailsOrder.xaml
    /// </summary>
    public partial class DetailsOrder : Page
    {
        

        public DetailsOrder()
        {
            InitializeComponent();
        }

        public MainWindow _mainWindow;
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _mainWindow.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog()==true)
                {
                    printDialog.PrintVisual(AddImportwd,"Hóa đơn");
                }
            }
            catch (Exception)
            {
                _mainWindow.IsEnabled = true;
            }
        }
    }
}
