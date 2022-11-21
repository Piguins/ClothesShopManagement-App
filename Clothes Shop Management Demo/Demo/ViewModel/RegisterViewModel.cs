//using Demo.Model;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class RegisterViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        //public ICommand SendPass { get; set; }
        public ICommand Movewd { get; set; }
        public RegisterViewModel()
        {
            Closewd = new RelayCommand<SignUpView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<SignUpView>((p) => true, (p) => Minimize(p));
            //SendPass = new RelayCommand<SignUpView>((p) => true, (p) => _SendPass(p));
            Movewd = new RelayCommand<SignUpView>((p) => true, (p) => _movewd(p));
        }
        void Close(SignUpView p)
        {
            p.Close();
        }
        void _movewd(SignUpView p)
        {
            p.DragMove();
        }
        void Minimize(SignUpView p)
        {
            p.WindowState = WindowState.Minimized;
        }
    }
}
