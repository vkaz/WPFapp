using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp
{
    public class LoginViewModel : MyTable
    {
        private bool _isAuthenticated;
        public bool isAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (value != _isAuthenticated)
                {
                    _isAuthenticated = value;
                    OnPropertyChanged("isAuthenticated");
                }
            }
        }
        private string _username;
        public new string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private int _admin;
        public new int Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged("Admin");
            }
        }
        private RelayCommand login;
        public ICommand LoginCommand
        {
            get { return login ??
                      (login = new RelayCommand(obj =>
                      {
                          DBCon.Password(_username.Trim(), _password.Trim());
                      }));
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
                        if (_username != null && _password != null && (_admin == 0 || _admin == 1))
                        {
                            string pass = HashPass.HashPassword(_password.Trim());
                            DBCon con = new DBCon();
                            string tsql = @"INSERT INTO [Users]
                    VALUES('" + _username.Trim() + "', '" + pass + "', '" + _admin + "')";
                            con.AddExt(tsql);
                        }
                    }));
            }
        }
       
        public void Login()
        {
            //TODO check username and password vs database here.
            //If using membershipprovider then just call Membership.ValidateUser(UserName, Password)
            if (!String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password))
                isAuthenticated = true;
        }
        
    }
}
