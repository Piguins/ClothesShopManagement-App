using Demo.Model;
using Demo.View;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Interop;
using System.Net.Mime;
using System.Collections.ObjectModel;

namespace Demo.ViewModel
{
    public class NotiCustomerViewModel : BaseViewModel
    {
        //List<KHACHHANG> notiCustomerList;
        public ICommand CustomerChanged { get; set; }
        public ICommand LoadCsCommand { get; set; }
        //public ICommand EmailChange { get; set; }
        private ObservableCollection<KHACHHANG> _listKH;
        public ObservableCollection<KHACHHANG> ListKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public NotiCustomerViewModel()
        {
            //_CustomerList();
            ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            LoadCsCommand = new RelayCommand<NotiCustomer>((p) => true, (p) => _LoadCsCommand(p));
            CustomerChanged = new RelayCommand<NotiCustomer>((p) => true, (p) => _CustomerChanged(p));
            SendAttachment = new RelayCommand<NotiCustomer>((p) => true, (p) => _SendAttachment(p));
            SendMSG = new RelayCommand<NotiCustomer>((p) => true, (p) => _SendMSG(p));
        }
        /*void _CustomerList()
        {
            foreach (KHACHHANG temp in DataProvider.Ins.DB.KHACHHANGs)
            {
                notiCustomerList.Add(temp);
            }
        }*/
        void _LoadCsCommand(NotiCustomer parameter)
        {
            parameter.CustomerList.SelectedIndex = 0;
            KHACHHANG temp = (KHACHHANG)parameter.CustomerList.SelectedItem;
            parameter.EmailAddress.Text = temp.EMAIL;
        }
        void _CustomerChanged(NotiCustomer parameter)
        {
                KHACHHANG temp = (KHACHHANG)parameter.CustomerList.SelectedItem;
                parameter.EmailAddress.Text = temp.EMAIL;
        }
        List<string> file_list;
        string[] files;
        public ICommand SendMSG { get; set; }
        public ICommand SendAttachment { get; set; }
        void _SendAttachment(NotiCustomer parameter)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "Select attached files";
                file.Multiselect = true;
                file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif";
                file.RestoreDirectory = true;
                if (file.ShowDialog() == true)
                {
                    file_list = new List<string>();
                    foreach (var item in file.FileNames)
                    {
                        file_list.Add(item);
                        if (!File.Exists(item))
                        {
                            MessageBox.Show("File does not exist! ", "Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                }
                files = file_list.ToArray();
                int filenum = file.FileNames.Count();
                parameter.attachButton.Content = "Attachments(" + filenum + ")";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void _SendMSG(NotiCustomer parameter)
        {
            MailMessage message = new MailMessage();
            Attachment attachment;
            message.From = new MailAddress("vhnm3004@gmail.com");
            message.To.Add(parameter.EmailAddress.Text);
            message.Subject = parameter.SubjectBox.Text;
            message.Body = parameter.BodyBox.Text;
            message.IsBodyHtml = true;
            foreach (var item in files)
            {
                attachment = new System.Net.Mail.Attachment(item);
                message.Attachments.Add(attachment);
            }
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential("vhnm3004@gmail.com", "snnaarxvfndqhptl");
            smtpClient.Send(message);
            MessageBox.Show("Đã gửi báo lỗi thành công!", "Thông báo");
        }
    }
}
