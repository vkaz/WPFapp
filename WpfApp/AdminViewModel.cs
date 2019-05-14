using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    class AdminViewModel : LoginViewModel
    {
        public ObservableCollection<Users> Users { get; set; }

        public AdminViewModel()
        {
            DBCon con = new DBCon();
            Users = con.Users();
        }
        private RelayCommand adm;
        public RelayCommand Adm
        {
            get
            {
                return adm ??
                    (adm = new RelayCommand(obj =>
                    {
                        Window3 win = new Window3();
                        win.ShowDialog();
                    }));
            }
        }
        private RelayCommand delUser;
        public RelayCommand DelUser
        {
            get
            {
                return delUser ??
                    (delUser = new RelayCommand(obj =>
                    {
                        MessageBox.Show(this.Name);
                    }));
            }
        }
    }
}
