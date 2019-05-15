using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp
{
    public class LoginViewModel : Property
    { 
        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
            }
        }
        private int _admin;
        public int Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged("Admin");
            }
        }
        private RelayCommand adduser;
        public ICommand AddUser
        {
            get
            {
                return adduser ??
                    (adduser = new RelayCommand(obj =>
                    {
                        if (_username != null && Password != null && (_admin == 0 || _admin == 1))
                        {
                            /*  string pass = HashPass.HashPassword(_pass.Trim());
                              DBCon con = new DBCon();
                              string tsql = @"INSERT INTO [Users]
                      VALUES('" + _username.Trim() + "', '" + pass + "', '" + _admin + "')";
                              con.AddExt(tsql);*/
                        }
                    }));
            }
        }
        private RelayCommand login;
        public ICommand LoginCommand
        {
            get
            {
                return login ??
                    (login = new RelayCommand(obj =>
                    {
                        if (_username != null && Password.Trim() != null && (_admin == 0 || _admin == 1))
                        {
                            DBCon.Password(_username, Password);
                        }
                    }));
            }
        }
        public ICommand PasswordChangedCommand
        {
            get
            {
                return new RelayCommand(ExecChangePassword);
            }
        }

        private string yourPassword;
        public string Password
        {
            private get { return yourPassword; }
            set
            {
                yourPassword = value;
            }
        }
        private void ExecChangePassword(object obj)
        {
            yourPassword = ((System.Windows.Controls.PasswordBox)obj).Password;
        }
    }
}
