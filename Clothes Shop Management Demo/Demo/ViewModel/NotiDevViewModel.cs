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

namespace Demo.ViewModel
{
    public class NotiDevViewModel : BaseViewModel
    {
        List<string> file_list;
        string[] files;
        public ICommand SendMSG { get; set; }
        public ICommand SendAttachment { get; set; }
        public NotiDevViewModel()
        {
            SendAttachment = new RelayCommand<NotiDev>((p) => true, (p) => _SendAttachment(p));
            SendMSG = new RelayCommand<NotiDev>((p) => true, (p) => _SendMSG(p));
        }
        void _SendAttachment(NotiDev parameter)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "Select attached files";
                file.Multiselect = true;
                file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif";
                file.RestoreDirectory = true;
                if (file.ShowDialog()==true)
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
                parameter.attachButton.Content="Attachments("+filenum+")";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void _SendMSG(NotiDev parameter)
        {
            MailMessage message = new MailMessage();
            Attachment attachment;
            string msg = parameter.MSGBox.Text;
            message.From = new MailAddress("vhnm3004@gmail.com");
            message.To.Add("vhnm3004@outlook.com");
            message.Subject = parameter.SubjectBox.Text;
            message.Body = parameter.MSGBox.Text;
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
