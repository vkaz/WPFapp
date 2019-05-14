using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class Users
    {
        public Users(string login, string pass, int adm)
        {
            Login = login;
            Password = pass;
            Admin = adm;
        }
        public int Admin { get; set; }
        public string Password { get; set; }

        public string Login { get; set; }
    }
}
