using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class Users
    {
        public Users(string login, int adm)
        {
            Login = login;
            Admin = adm;
        }
        public int Admin { get; set; }
        public string Login { get; set; }
    }
}
