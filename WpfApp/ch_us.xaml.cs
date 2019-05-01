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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для ch_us.xaml
    /// </summary>
    public partial class ch_us : Window
    {
        public ch_us()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp.localDBDataSet localDBDataSet = ((WpfApp.localDBDataSet)(this.FindResource("localDBDataSet")));
            // Загрузить данные в таблицу Users. Можно изменить этот код как требуется.
            WpfApp.localDBDataSetTableAdapters.UsersTableAdapter localDBDataSetUsersTableAdapter = new WpfApp.localDBDataSetTableAdapters.UsersTableAdapter();
            localDBDataSetUsersTableAdapter.Fill(localDBDataSet.Users);
            System.Windows.Data.CollectionViewSource usersViewSource = ((CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
        }
    }
}
